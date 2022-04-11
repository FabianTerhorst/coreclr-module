namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IModuleTimer
    {
        long LastRun { get; }
        Action Callback { get; }
        uint Interval { get; }
        bool Once { get; }
        string Location { get; }
        bool Update(long curTime);
    }
}