namespace AltV.Net.Client.Elements.Entities
{
    public interface ILocalPlayer : IPlayer
    {
        public IntPtr LocalPlayerNativePointer { get; }
    }
}