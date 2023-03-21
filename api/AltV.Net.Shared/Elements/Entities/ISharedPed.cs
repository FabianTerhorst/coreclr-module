namespace AltV.Net.Shared.Elements.Entities;

public interface ISharedPed : ISharedEntity
{
    IntPtr PedNativePointer { get; }

}