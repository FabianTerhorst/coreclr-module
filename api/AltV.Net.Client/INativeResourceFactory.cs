namespace AltV.Net.Client
{
    public interface INativeResourceFactory
    {
        INativeResource Create(ICore core, IntPtr resourcePointer);
    }
}