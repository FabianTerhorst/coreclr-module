using AltV.Net.CApi;
using AltV.Net.Client.Elements;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client
{
    public interface IResource
    {
        public void OnStart();
        public void OnStop();
        public void OnTick();
        public UnhandledExceptionHandingOptions OnUnhandledException(UnhandledExceptionEventArgs e);
        public INatives GetNatives(ILibrary library);
        public IPlayerFactory GetPlayerFactory();
        public IEntityFactory<IVehicle> GetVehicleFactory();
        public IEntityFactory<IPed> GetPedFactory();
        public IBaseObjectFactory<IBlip> GetBlipFactory();
        public IBaseObjectFactory<ICheckpoint> GetCheckpointFactory();
        public IBaseObjectFactory<IColShape> GetColShapeFactory();
        public IBaseObjectFactory<IAudio> GetAudioFactory();
        public IBaseObjectFactory<IHttpClient> GetHttpClientFactory();
        public IBaseObjectFactory<IWebSocketClient> GetWebSocketClientFactory();
        public IBaseObjectFactory<IWebView> GetWebViewFactory();
        public IEntityFactory<IObject> GetObjectFactory();
        public IBaseObjectFactory<IVirtualEntity> GetVirtualEntityFactory();
        public IBaseObjectFactory<IVirtualEntityGroup> GetVirtualEntityGroupFactory();
        public IBaseObjectFactory<ITextLabel> GetTextLabelFactory();
        public IBaseObjectFactory<ILocalVehicle> GetLocalVehicleFactory();
        public IBaseObjectFactory<ILocalPed> GetLocalPedFactory();
        public INativeResourceFactory GetResourceFactory();
        public ILogger GetLogger(ILibrary library, IntPtr corePointer);
    }
}