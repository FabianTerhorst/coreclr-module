namespace AltV.Net.ResourceLoaders
{
    public class ScriptLoader
    {
        private readonly AssemblyLoader assemblyLoader;

        public ScriptLoader(AssemblyLoader assemblyLoader)
        {
            this.assemblyLoader = assemblyLoader;
        }

        public IScript[] GetAllScripts() => assemblyLoader.FindAllTypes<IScript>();
    }
}