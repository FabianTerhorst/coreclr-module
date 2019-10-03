namespace AltV.Net
{
    public interface IModule
    {
        void OnScriptsStarted(IScript[] scripts);

        void OnStop();
    }
}