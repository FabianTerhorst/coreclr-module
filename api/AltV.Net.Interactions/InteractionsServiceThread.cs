using System;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Interactions;

public class InteractionsServiceThread : IDisposable
{
    private readonly int threadIndex;

    private readonly ulong[] types;

    private readonly Grid grid;

    private readonly Channel<InteractionsServiceThreadEvent> channel =
        Channel.CreateUnbounded<InteractionsServiceThreadEvent>(new UnboundedChannelOptions {SingleReader = true});

    public readonly ChannelWriter<InteractionsServiceThreadEvent> Writer;

    private const string DllName = "csharp-module";
    private const CallingConvention NativeCallingConvention = CallingConvention.Cdecl;

    [DllImport(DllName, CallingConvention = NativeCallingConvention)]
    private static extern unsafe void Player_GetPositionCoords(void* player, float* positionX, float* positionY,
        float* positionZ, int* dimension);

    public InteractionsServiceThread(int threadIndex, ulong[] types, Grid grid)
    {
        this.threadIndex = threadIndex;
        this.types = types;
        this.grid = grid;
        Writer =  channel.Writer;
        
        Task.Run(async () =>
            {
                while (await channel.Reader.WaitToReadAsync())
                {
                    while (channel.Reader.TryRead(out var interactionEvent))
                    {
                        switch (interactionEvent.EventType)
                        {
                            case 0:
                                grid.Add((IInteraction) interactionEvent.Data);
                                break;
                            case 1:
                                grid.Remove((IInteraction) interactionEvent.Data);
                                break;
                            case 2:
                            {
                                var player = (IPlayer) interactionEvent.Data;
                                float x;
                                float y;
                                float z;
                                int currDimension;
                                lock (player)
                                {
                                    if (player.Exists)
                                    {
                                        unsafe
                                        {
                                            Player_GetPositionCoords(player.NativePointer.ToPointer(), &x, &y, &z,
                                                &currDimension);
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                var interactionPosition = new Vector3(x, y, z);
                                var foundInteractions = grid.Find(interactionPosition, currDimension);
                                if (foundInteractions != null)
                                {
                                    foreach (var interaction in foundInteractions)
                                    {
                                        try
                                        {
                                            if (interaction.OnInteraction(player, interactionPosition, currDimension))
                                            {
                                                break;
                                            }
                                        }
                                        catch (Exception exception)
                                        {
                                            Console.WriteLine("interaction " + interaction + " threw a exception.");
                                            Console.WriteLine(exception);
                                        }
                                    }
                                }

                                break;
                            }
                            case 3:
                            {
                                var (interactionPosition, currDimension, callback) =
                                    ((Vector3, int, TaskCompletionSource<IInteraction[]>)) interactionEvent.Data;
                                callback.SetResult(grid.Find(interactionPosition, currDimension).ToArray());
                                break;
                            }
                        }
                    }
                }
            });
    }

    public void Dispose()
    {
        channel.Writer.Complete();
    }
}