namespace AltV.Net
{
    public interface IResource
    {
        void OnStart();

        void OnStop();

        IPlayerFactory GetPlayerFactory();
        IVehicleFactory GetVehicleFactory();
        IBlipFactory GetBlipFactory();
        ICheckpointFactory GetCheckpointFactory();
    }
}