namespace AltV.Net
{
    public interface IResource
    {
        void OnStart();
        void OnStop();
        IVehicleFactory GetVehicleFactory();
    }
}