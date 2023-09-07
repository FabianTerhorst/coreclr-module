using AltV.Net.CApi;
using AltV.Net.CApi.Libraries;
using AltV.Net.Client.Elements;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client
{
    public abstract class Resource : IResource
    {
        public abstract void OnStart();

        public abstract void OnStop();

        public virtual void OnTick()
        {
        }

        public virtual UnhandledExceptionHandingOptions OnUnhandledException(UnhandledExceptionEventArgs e)
        {
            return new UnhandledExceptionHandingOptions();
        }

        public virtual IPlayerFactory GetPlayerFactory()
        {
            return new PlayerFactory();
        }

        public virtual INatives GetNatives(ILibrary library)
        {
            return new Natives(library);
        }

        public virtual IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new VehicleFactory();
        }

        public virtual IEntityFactory<IPed> GetPedFactory()
        {
            return new PedFactory();
        }

        public virtual IBaseObjectFactory<IBlip> GetBlipFactory()
        {
            return new BlipFactory();
        }

        public virtual IBaseObjectFactory<ICheckpoint> GetCheckpointFactory()
        {
            return new CheckpointFactory();
        }

        public virtual IBaseObjectFactory<IColShape> GetColShapeFactory()
        {
            return new ColShapeFactory();
        }

        public virtual IBaseObjectFactory<IWebView> GetWebViewFactory()
        {
            return new WebViewFactory();
        }

        public virtual IEntityFactory<ILocalObject> GetLocalObjectFactory()
        {
            return new LocalObjectFactory();
        }

        public virtual IEntityFactory<IObject> GetObjectFactory()
        {
            return new ObjectFactory();
        }

        public virtual IBaseObjectFactory<IVirtualEntity> GetVirtualEntityFactory()
        {
            return new VirtualEntityFactory();
        }

        public virtual IBaseObjectFactory<IVirtualEntityGroup> GetVirtualEntityGroupFactory()
        {
            return new VirtualEntityGroupFactory();
        }

        public virtual IBaseObjectFactory<ITextLabel> GetTextLabelFactory()
        {
            return new TextLabelFactory();
        }

        public virtual IBaseObjectFactory<ILocalVehicle> GetLocalVehicleFactory()
        {
            return new LocalVehicleFactory();
        }

        public virtual IBaseObjectFactory<ILocalPed> GetLocalPedFactory()
        {
            return new LocalPedFactory();
        }

        public virtual IBaseObjectFactory<IAudioFilter> GetAudioFilterFactory()
        {
            return new AudioFilterFactory();
        }

        public virtual IBaseObjectFactory<IAudioOutput> GetAudioOutputFactory()
        {
            return new AudioOutputFactory();
        }

        public virtual IBaseObjectFactory<IAudioWorldOutput> GetAudioWorldOutputFactory()
        {
            return new AudioWorldOutputFactory();
        }

        public virtual IBaseObjectFactory<IFont> GetFontFactory()
        {
            return new FontFactory();
        }

        public virtual IBaseObjectFactory<IMarker> GetMarkerFactory()
        {
            return new MarkerFactory();
        }

        public virtual IBaseObjectFactory<IAudioAttachedOutput> GetAudioAttachedOutputFactory()
        {
            return new AudioAttachedOutputFactory();
        }

        public virtual IBaseObjectFactory<IAudioFrontendOutput> GetAudioFrontendOutputFactory()
        {
            return new AudioFrontendOutputFactory();
        }

        public virtual IBaseObjectFactory<IAudio> GetAudioFactory()
        {
            return new AudioFactory();
        }

        public virtual IBaseObjectFactory<IHttpClient> GetHttpClientFactory()
        {
            return new HttpClientFactory();
        }

        public virtual IBaseObjectFactory<IWebSocketClient> GetWebSocketClientFactory()
        {
            return new WebSocketClientFactory();
        }

        public virtual INativeResourceFactory GetResourceFactory()
        {
            return new NativeResourceFactory();
        }

        public virtual ILogger GetLogger(ILibrary library, IntPtr corePointer)
        {
            return new Logger(library, corePointer);
        }
    }
}