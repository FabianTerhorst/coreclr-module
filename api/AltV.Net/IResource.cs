using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net
{
    //TODO: add SubResource module maybe to load sub resources dependency dlls or just for own server architecture
    public interface IResource
    {
        void OnStart();

        void OnStop();

        void OnTick();

        //TODO: default implementation in c# 8.0
        IBaseEntityPool GetBaseEntityPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool);

        IBaseBaseObjectPool GetBaseBaseObjectPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool, IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool, IBaseObjectPool<IColShape> colShapePool);

        IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory);
        IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory);
        IBaseObjectPool<IBlip> GetBlipPool(IBaseObjectFactory<IBlip> blipFactory);
        IBaseObjectPool<ICheckpoint> GetCheckpointPool(IBaseObjectFactory<ICheckpoint> checkpointFactory);
        IBaseObjectPool<IVoiceChannel> GetVoiceChannelPool(IBaseObjectFactory<IVoiceChannel> voiceChannelFactory);
        IBaseObjectPool<IColShape> GetColShapePool(IBaseObjectFactory<IColShape> colShapeFactory);

        IEntityFactory<IPlayer> GetPlayerFactory();
        IEntityFactory<IVehicle> GetVehicleFactory();
        IBaseObjectFactory<IBlip> GetBlipFactory();
        IBaseObjectFactory<ICheckpoint> GetCheckpointFactory();
        IBaseObjectFactory<IVoiceChannel> GetVoiceChannelFactory();
        IBaseObjectFactory<IColShape> GetColShapeFactory();

        Module GetModule(IServer server, CSharpNativeResource cSharpNativeResource,
            IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool,
            IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool);
    }

    public static class ResourceExtensions
    {
        public static void Start(this IResource resource, string[] args) =>
            new ResourceBuilder(args, resource).Start();
    }
}