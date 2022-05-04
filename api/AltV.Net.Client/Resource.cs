using AltV.Net.CApi;
using AltV.Net.Client.Elements;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client
{
    public abstract class Resource : IResource
    {
        public abstract void OnStart();

        public abstract void OnStop();

        public virtual IPlayerFactory GetPlayerFactory()
        {
            return new PlayerFactory();
        }
        
        public virtual INatives GetNatives(string dllName)
        {
            return new Natives(dllName);
        }

        public virtual IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new VehicleFactory();
        }
        
        public virtual IBaseObjectFactory<IBlip> GetBlipFactory()
        {
            return new BlipFactory();
        }
        
        public virtual IBaseObjectFactory<ICheckpoint> GetCheckpointFactory()
        {
            return new CheckpointFactory();
        }
        
        public IBaseObjectFactory<IWebView> GetWebViewFactory()
        {
            return new WebViewFactory();
        }
        
        public IBaseObjectFactory<IAudio> GetAudioFactory()
        {
            return new AudioFactory();
        }
        
        public IBaseObjectFactory<IHttpClient> GetHttpClientFactory()
        {
            return new HttpClientFactory();
        }
        
        public IBaseObjectFactory<IWebSocketClient> GetWebSocketClientFactory()
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