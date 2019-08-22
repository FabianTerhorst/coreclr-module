namespace AltV.Net
{
    public interface INativeResource
    {
        string Path { get; }
        
        string Name { get; }
        
        string Main { get; }
        
        string Type { get; }
        
        ResourceState State { get; }

        void SetExport(string key, object value);
        
        void Start();

        void Stop();
    }
}