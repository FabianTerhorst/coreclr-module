using System;
using System.Linq;
using System.Numerics;
using AltV.Net.Elements.Entities;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AltV.Net.Interactions
{
    public static class AltInteractions
    {
        private const string DllName = "csharp-module";
        private const CallingConvention NativeCallingConvention = CallingConvention.Cdecl;

        [DllImport(DllName, CallingConvention = NativeCallingConvention)]
        private static extern unsafe void Player_GetPositionCoords(void* player, float* positionX, float* positionY,
            float* positionZ, int* dimension);

        private static Grid _spatialPartition;

        private readonly struct InteractionEvent
        {
            public readonly byte EventType;

            public readonly object Data;

            public InteractionEvent(byte eventType, object data)
            {
                this.EventType = eventType;
                this.Data = data;
            }
        }

        private static readonly Channel<InteractionEvent> InteractionChannel =
            Channel.CreateUnbounded<InteractionEvent>(new UnboundedChannelOptions {SingleReader = true});

        public static void Init(int maxX = 50_000, int maxY = 50_000, int areaSize = 100, int xOffset = 10_000, int yOffset = 10_000)
        {
            Init(new Grid(maxX, maxY, areaSize, xOffset, yOffset));
        }

        public static void Init(Grid spatialPartition)
        {
            _spatialPartition = spatialPartition;
            Task.Run(async () =>
            {
                while (await InteractionChannel.Reader.WaitToReadAsync())
                {
                    while (InteractionChannel.Reader.TryRead(out var interactionEvent))
                    {
                        switch (interactionEvent.EventType)
                        {
                            case 0:
                                _spatialPartition.Add((IInteraction) interactionEvent.Data);
                                break;
                            case 1:
                                _spatialPartition.Remove((IInteraction) interactionEvent.Data);
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
                                var foundInteractions = _spatialPartition.Find(interactionPosition, currDimension);
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
                                callback.SetResult(_spatialPartition.Find(interactionPosition, currDimension).ToArray());
                                break;
                            }
                        }
                    }
                }
            });
        }

        public static void AddInteraction(IInteraction interaction)
        {
            InteractionChannel.Writer.TryWrite(new InteractionEvent(0, interaction));
        }

        public static void RemoveInteraction(IInteraction interaction)
        {
            InteractionChannel.Writer.TryWrite(new InteractionEvent(1, interaction));
        }

        public static void TriggerInteractions(IPlayer player)
        {
            InteractionChannel.Writer.TryWrite(new InteractionEvent(2, player));
        }

        public static Task<IInteraction[]> FindInteractions(Vector3 position, int dimension)
        {
            var callback = new TaskCompletionSource<IInteraction[]>();
            InteractionChannel.Writer.TryWrite(new InteractionEvent(3, (position, dimension, callback)));
            return callback.Task;
        }

        public static void Dispose()
        {
            InteractionChannel.Writer.Complete();
        }
    }
}