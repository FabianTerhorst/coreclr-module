namespace AltV.Net.Client.Elements
{
    public interface ILogger
    {
        public void LogInfo(string message);
        public void LogError(string message);
        void LogWarning(string message);
        void LogDebug(string message);
    }
}