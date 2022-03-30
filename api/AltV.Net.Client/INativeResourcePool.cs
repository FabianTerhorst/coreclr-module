namespace AltV.Net.Client
{
    public interface INativeResourcePool
    {
        bool GetOrCreate(ICore core, IntPtr resourcePointer, out INativeResource resource);
    }
}