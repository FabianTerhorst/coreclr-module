using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public static class MockCheckpointEvents
    {
        public static void EntityEnter(this ICheckpoint checkpoint, IEntity entity)
        {
            Alt.Module.OnCheckpoint(checkpoint.NativePointer, entity.NativePointer, entity.Type, true);
        }

        public static void EntityExit(this ICheckpoint checkpoint, IEntity entity)
        {
            Alt.Module.OnCheckpoint(checkpoint.NativePointer, entity.NativePointer, entity.Type, false);
        }
    }
}