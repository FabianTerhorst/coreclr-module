using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static IPlayer ToAsync(this IPlayer player, IAsyncContext asyncContext) => asyncContext.CreateRef(player) ?
            new AsyncPlayer(player, asyncContext) : null;
        
        public static IVehicle ToAsync(this IVehicle vehicle, IAsyncContext asyncContext) => asyncContext.CreateRef(vehicle) ?
            new AsyncVehicle(vehicle, asyncContext) : null;
        
        public static ICheckpoint ToAsync(this ICheckpoint checkpoint, IAsyncContext asyncContext) => asyncContext.CreateRef(checkpoint) ?
            new AsyncCheckpoint(checkpoint, asyncContext) : null;
        
        public static IColShape ToAsync(this IColShape colShape, IAsyncContext asyncContext) => asyncContext.CreateRef(colShape) ?
            new AsyncColShape<IColShape>(colShape, asyncContext) : null;
        
        public static IBlip ToAsync(this IBlip blip, IAsyncContext asyncContext) => asyncContext.CreateRef(blip) ?
            new AsyncBlip(blip, asyncContext) : null;
        
        public static IVoiceChannel ToAsync(this IVoiceChannel voiceChannel, IAsyncContext asyncContext) => asyncContext.CreateRef(voiceChannel) ?
            new AsyncVoiceChannel(voiceChannel, asyncContext) : null;
    }
}