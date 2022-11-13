using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static IPlayer ToAsync(this IPlayer player, IAsyncContext asyncContext) =>
            asyncContext == null ? new AsyncPlayer(player, asyncContext) : null;

        public static IVehicle ToAsync(this IVehicle vehicle, IAsyncContext asyncContext) =>
            asyncContext == null ? new AsyncVehicle(vehicle, asyncContext) : null;

        public static ICheckpoint ToAsync(this ICheckpoint checkpoint, IAsyncContext asyncContext) =>
            asyncContext == null ? new AsyncCheckpoint(checkpoint, asyncContext) : null;

        public static IColShape ToAsync(this IColShape colShape, IAsyncContext asyncContext) =>
            asyncContext == null ? new AsyncColShape(colShape, asyncContext) : null;

        public static IBlip ToAsync(this IBlip blip, IAsyncContext asyncContext) =>
            asyncContext == null ? new AsyncBlip(blip, asyncContext) : null;

        public static IVoiceChannel ToAsync(this IVoiceChannel voiceChannel, IAsyncContext asyncContext) =>
            asyncContext == null ? new AsyncVoiceChannel(voiceChannel, asyncContext) : null;

        public static IPlayer ToAsync(this IPlayer player) => new AsyncPlayer(player, null);

        public static IVehicle ToAsync(this IVehicle vehicle) => new AsyncVehicle(vehicle, null);

        public static ICheckpoint ToAsync(this ICheckpoint checkpoint) => new AsyncCheckpoint(checkpoint, null);

        public static IColShape ToAsync(this IColShape colShape) => new AsyncColShape(colShape, null);

        public static IBlip ToAsync(this IBlip blip) => new AsyncBlip(blip, null);

        public static IVoiceChannel ToAsync(this IVoiceChannel voiceChannel) => new AsyncVoiceChannel(voiceChannel, null);

        public static bool TryToAsync(this IPlayer thisValue, IAsyncContext asyncContext, out IPlayer player)
        {
            player = new AsyncPlayer(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this IVehicle thisValue, IAsyncContext asyncContext, out IVehicle vehicle)
        {
            vehicle = new AsyncVehicle(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this ICheckpoint thisValue, IAsyncContext asyncContext,
            out ICheckpoint checkpoint)
        {
            checkpoint = new AsyncCheckpoint(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this IColShape thisValue, IAsyncContext asyncContext, out IColShape colShape)
        {
            colShape = new AsyncColShape(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this IBlip thisValue, IAsyncContext asyncContext, out IBlip blip)
        {
            blip = new AsyncBlip(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this IVoiceChannel thisValue, IAsyncContext asyncContext,
            out IVoiceChannel voiceChannel)
        {
            voiceChannel = new AsyncVoiceChannel(thisValue, asyncContext);
            return true;
        }
    }
}