using System.Numerics;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using System.Runtime.InteropServices;

namespace AltV.Net.EntitySync.ServerEvent
{
    public class PlayerClient : Client
    {
        private const string DllName = "csharp-module";
        private const CallingConvention NativeCallingConvention = CallingConvention.Cdecl;

#if NET5_0
        [SuppressGCTransition]
        [DllImport(DllName, CallingConvention = NativeCallingConvention)]
        private static extern unsafe void Player_GetPositionCoords(void* player, float* positionX, float* positionY,
            float* positionZ, int* dimension);
        #else
        [DllImport(DllName, CallingConvention = NativeCallingConvention)]
        private static extern unsafe void Player_GetPositionCoords(void* player, float* positionX, float* positionY,
            float* positionZ, int* dimension);
#endif

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

        private Vector3 positionOverride;

        private bool positionOverrideEnabled;

        public override int Dimension
        {
            get
            {
                lock (player)
                {
                    if (player.Exists)
                    {
                        return player.Dimension;
                    }
                }

                return default;
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

        public PlayerClient(ulong threadCount, string token, IPlayer player) : base(threadCount, token)
        {
            this.player = player;
        }

        public override bool TryGetDimensionAndPosition(out int dimension, ref Vector3 position)
        {
            lock (player)
            {
                if (player.Exists)
                {
                    if (positionOverrideEnabled)
                    {
                        position = positionOverride;
                        dimension = player.Dimension;
                    }
                    else
                    {
                        unsafe
                        {
                            float x;
                            float y;
                            float z;
                            int currDimension;
                            Player_GetPositionCoords(player.NativePointer.ToPointer(), &x, &y, &z, &currDimension);
                            position.X = x;
                            position.Y = y;
                            position.Z = z;
                            dimension = currDimension;
                        }
                    }

                    return true;
                }
            }

            position = Vector3.Zero;
            dimension = default;
            return false;
        }

        public override void SetPositionOverride(Vector3 newPositionOverride)
        {
            lock (player)
            {
                if (!player.Exists) return;
                positionOverride = newPositionOverride;
                positionOverrideEnabled = true;
            }
        }

        public override void ResetPositionOverride()
        {
            lock (player)
            {
                if (player.Exists)
                {
                    positionOverrideEnabled = false;
                }
            }
        }

        public void Emit(string eventName, params object[] args)
        {
            player.EmitLocked(eventName, args);
        }

        public IPlayer GetPlayer()
        {
            return player;
        }
    }
}