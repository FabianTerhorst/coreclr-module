namespace AltV.Net
{
    public interface INativeResource
    {
        void SetExport(string key, object value);

        string Path { get; }
        
        string Name { get; }
        
        string Main { get; }
        
        string Type { get; }
        
        ResourceState State { get; }
    }
}