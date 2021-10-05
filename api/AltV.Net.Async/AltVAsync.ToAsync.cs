using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static IPlayer ToAsync(this IPlayer player, IAsyncContext asyncContext) =>
            new AsyncPlayer(player, asyncContext);
        
        public static IVehicle ToAsync(this IVehicle vehicle, IAsyncContext asyncContext) =>
            new AsyncVehicle(vehicle, asyncContext);
        
        public static ICheckpoint ToAsync(this ICheckpoint checkpoint, IAsyncContext asyncContext) =>
            new AsyncCheckpoint(checkpoint, asyncContext);
        
        public static IColShape ToAsync(this IColShape colShape, IAsyncContext asyncContext) =>
            new AsyncColShape<IColShape>(colShape, asyncContext);
        
        public static IBlip ToAsync(this IBlip blip, IAsyncContext asyncContext) =>
            new AsyncBlip(blip, asyncContext);
        
        public static IVoiceChannel ToAsync(this IVoiceChannel voiceChannel, IAsyncContext asyncContext) =>
            new AsyncVoiceChannel(voiceChannel, asyncContext);
    }
}