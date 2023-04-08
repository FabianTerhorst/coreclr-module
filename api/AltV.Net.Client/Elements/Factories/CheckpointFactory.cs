using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class CheckpointFactory : IBaseObjectFactory<ICheckpoint>
    {
        public ICheckpoint Create(ICore core, IntPtr blipPointer, uint id)
        {
            return new Checkpoint(core, blipPointer, id);
        }
    }
}