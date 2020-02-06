using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.RPC
{
    //TODO: move to own Alt.Net.Rpc package so it doesnt get loaded for all that include async
    /*public class AsyncRpcModule// : IModule
    {
        private static readonly IDictionary<IPlayer, SemaphoreSlim> PlayerSemaphores = new Dictionary<IPlayer, SemaphoreSlim>();
        
        //TODO: task with channel as in networking entity
        public void OnScriptsStarted(IScript[] scripts)
        {
            Alt.On<IPlayer, ulong>("rpc", OnRpc, OnRpcParser);
            Alt.On<IPlayer>("rpc:single", OnRpcSingle, OnRpcSingleParser);
            Alt.OnPlayerDisconnect += OnPlayerDisconnect;
            AsyncRpc.EmitSingleFunc = EmitSingle;
        }

        public void OnStop()
        {
            Alt.OnPlayerDisconnect -= OnPlayerDisconnect;
        }

        private static async Task EmitSingle(IPlayer player, string eventName, object data)
        {
            SemaphoreSlim semaphoreSlim;
            lock (PlayerSemaphores)
            {
                if (!PlayerSemaphores.TryGetValue(player, out semaphoreSlim))
                {
                    semaphoreSlim = new SemaphoreSlim(1);
                    PlayerSemaphores[player] = semaphoreSlim;
                }
            }

            await semaphoreSlim.WaitAsync();
            lock (player)
            {
                if (player.Exists)
                {
                    player.Emit(eventName, data);
                }
            }
        }

        public static void OnPlayerDisconnect(IPlayer player, string reason)
        {
            SemaphoreSlim semaphoreSlim;
            lock (PlayerSemaphores)
            {
                if (!PlayerSemaphores.Remove(player, out semaphoreSlim))
                {
                    return;
                }
            }
            semaphoreSlim.Release();
        }

        /// <summary>
        /// Triggers when rpc event is done from player site
        /// </summary>
        /// <param name="player"></param>
        public static void OnRpcSingle(IPlayer player)
        {
            SemaphoreSlim semaphoreSlim;
            lock (PlayerSemaphores)
            {
                if (!PlayerSemaphores.TryGetValue(player, out semaphoreSlim))
                {
                    return;
                }
            }

            semaphoreSlim.Release();
        }
        
        public static void OnRpcSingleParser(IPlayer player, MValueConst[] args, Action<IPlayer> action)
        {
            if (args.Length != 0) return;
            action(player);
        }

        public static void OnRpc(IPlayer player, ulong id)
        {
        }

        public static void OnRpcParser(IPlayer player, MValueConst[] args, Action<IPlayer, ulong> action)
        {
            if (args.Length != 1) return;
            var arg = args[0];
            arg.AddRef();
            Task.Run(() =>
            {
                try
                {
                    switch (arg.type)
                    {
                        case MValueConst.Type.INT:
                        {
                            var value = arg.GetInt();
                            if (value < 0) return;
                            action(player, (ulong) value);
                            break;
                        }
                        case MValueConst.Type.UINT:
                        {
                            var value = arg.GetUint();
                            action(player, value);
                            break;
                        }
                    }
                }
                finally
                {
                    arg.RemoveRef();
                }
            });
        }
    }*/
}