using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Interactions;

public class InteractionsService: IDisposable
{
    private readonly InteractionsServiceThread[] threads;

    private readonly InteractionsServiceThread[] threadToTypeIndex;

    private readonly Func<ulong, ulong, ulong> globalThreadMapping;

    internal InteractionsService(IReadOnlySet<ulong> types,
        IReadOnlyList<(ulong[], Grid)> threadIndexes, Func<ulong, ulong, ulong> globalThreadMapping)
    {
        if (globalThreadMapping == null)
        {
            var length = threadIndexes.Count;
            threadToTypeIndex = new InteractionsServiceThread[types.Max() + 1];
            threads = new InteractionsServiceThread[length];
            this.globalThreadMapping = null;
            var allocatedTypes = new HashSet<ulong>(types);
            for (var threadIndex = 0; threadIndex < length; ++threadIndex)
            {
                var (typesForThread, grid) = threadIndexes[threadIndex];
                if (typesForThread == null)
                {
                    throw new ArgumentException(
                        "You have to use .AddThreadWithType when you don't use .AddGlobalThreadMapping");
                }
                
                foreach (var currType in types)
                {
                    if (typesForThread.Any(currThreadType => currType == currThreadType)) continue;
                    throw new ArgumentException(
                        "You have to use .AddType to add a type. Missing type: " + currType);
                }

                var currThread = new InteractionsServiceThread(threadIndex, typesForThread, grid);

                foreach (var currThreadType in typesForThread)
                {
                    if (!allocatedTypes.Remove(currThreadType))
                    {
                        throw new ArgumentException(
                            "You can only use one type in one thread. Type used in multiple threads: " + currThreadType);
                    }
                    threadToTypeIndex[currThreadType] = currThread;
                }

                threads[threadIndex] = currThread;
            }
        }
        else
        {
            var length = threadIndexes.Count;
            threadToTypeIndex = null;
            threads = new InteractionsServiceThread[length];
            this.globalThreadMapping = globalThreadMapping;
            for (var threadIndex = 0; threadIndex < length; ++threadIndex)
            {
                var (typesForThread, grid) = threadIndexes[threadIndex];
                if (typesForThread == null)
                {
                    throw new ArgumentException(
                        "You have to use .AddThread when you use .AddGlobalThreadMapping");
                }
                
                var currThread = new InteractionsServiceThread(threadIndex, typesForThread, grid);

                threads[threadIndex] = currThread;
            }
        }
    }

    public static InteractionsServiceBuilder CreateBuilder(InteractionsServiceOptions serviceOptions = null)
    {
        return new InteractionsServiceBuilder(serviceOptions ?? new InteractionsServiceOptions());
    }

    public void Add(IInteraction interaction)
    {
        if (threadToTypeIndex == null)
        {
            threads[globalThreadMapping(interaction.Type, interaction.Id)].Writer.TryWrite(new InteractionsServiceThreadEvent(0, interaction));
            return;
        }
        threadToTypeIndex[interaction.Type].Writer.TryWrite(new InteractionsServiceThreadEvent(0, interaction));
    }

    public void Remove(IInteraction interaction)
    {
        if (threadToTypeIndex == null)
        {
            threads[globalThreadMapping(interaction.Type, interaction.Id)].Writer.TryWrite(new InteractionsServiceThreadEvent(1, interaction));
            return;
        }
        threadToTypeIndex[interaction.Type].Writer.TryWrite(new InteractionsServiceThreadEvent(1, interaction));
    }

    public void Trigger(ulong type, IPlayer player, object argument = null/*in Vector3 position, int dimension*/)
    {
        if (threadToTypeIndex == null)
        {
            for (int i = 0, length = threads.Length; i < length; ++i) {
                threads[i].Writer.TryWrite(new InteractionsServiceThreadEvent(2, (player, argument)));
            }
            return;
        }
        threadToTypeIndex[type].Writer.TryWrite(new InteractionsServiceThreadEvent(2, (player, argument)));
    }
    
    public Task<IInteraction[]> Find(ulong type, Vector3 position, int dimension)
    {
        if (threadToTypeIndex == null)
        {
            return Task.Run(async () =>
            {
                var interactions = new List<IInteraction>();
                for (int i = 0, length = threads.Length; i < length; ++i) {
                    var callback = new TaskCompletionSource<IInteraction[]>(TaskCreationOptions.RunContinuationsAsynchronously);
                    threads[i].Writer.TryWrite(new InteractionsServiceThreadEvent(3, (position, dimension, callback)));
                    interactions.AddRange(await callback.Task);
                }

                return interactions.ToArray();
            });
        }
        var callback = new TaskCompletionSource<IInteraction[]>(TaskCreationOptions.RunContinuationsAsynchronously);
        threadToTypeIndex[type].Writer.TryWrite(new InteractionsServiceThreadEvent(3, (position, dimension, callback)));
        return callback.Task;
    }

    public void Dispose()
    {
        for (int i = 0, length = threads.Length; i < length; ++i) {
            threads[i].Dispose();
            threads[i] = null;
        }
        for (int i = 0, length = threadToTypeIndex.Length; i < length; ++i) {
            threadToTypeIndex[i] = null;
        }
    }
}