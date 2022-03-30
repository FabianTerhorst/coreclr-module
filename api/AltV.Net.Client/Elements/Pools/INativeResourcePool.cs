namespace AltV.Net.Client.Elements.Pools
{
    public interface INativeResourcePool
    {
        bool GetOrCreate(ICore core, IntPtr resourcePointer, out INativeResource resource);
    }
}