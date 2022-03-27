using AltV.Net.Elements.Args;

namespace AltV.Net.Shared
{
    public interface ISharedNativeResource
    {
        ISharedCSharpResourceImpl CSharpResourceImpl { get; }
        
        IntPtr ResourceImplPtr { get; }

        string Name { get; }

        string Type { get; }

        bool IsStarted { get; }
        
        string[] Dependencies { get; }
        
        string[] Dependants { get; }

        void SetExport(string key, object value);
        
        void SetExport(string key, in MValueConst value);

        object GetExport(string key);

        bool GetExport(string key, out MValueConst mValue);
    }
}