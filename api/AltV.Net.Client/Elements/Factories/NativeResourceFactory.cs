namespace AltV.Net.Client.Elements.Factories
{
    public class NativeResourceFactory : INativeResourceFactory
    {
        public INativeResource Create(ICore core, IntPtr resourcePointer)
        {
            return new NativeResource(core, resourcePointer);
        }
    }
}