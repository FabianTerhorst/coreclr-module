using System.Numerics;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;

namespace AltV.Net.EntitySync.ServerEvent
{
    public class PlayerClient : Client
    {
        private readonly IPlayer player;

        public override Vector3 Position
        {
            get
            {
                lock (player)
                {
                    if (player.Exists)
                    {
                        return player.Position;
                    }
                }

                return Vector3.Zero;
            }
        }

        public override bool Exists
        {
            get
            {
                lock (player)
                {
                    if (player.Exists)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public PlayerClient(string token, IPlayer player) : base(token)
        {
            this.player = player;
        }

        public override bool TryGetPosition(out Vector3 position)
        {
            lock (player)
            {
                if (player.Exists)
                {
                    position = player.Position;
                    return true;
                }
            }
            position = Vector3.Zero;
            return false;
        }

        public void Emit(string eventName, params object[] args)
        {
            player.EmitLocked(eventName, args);
        }
    }
}