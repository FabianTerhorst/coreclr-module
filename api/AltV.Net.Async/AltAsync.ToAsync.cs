using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static IPlayer ToAsync(this IPlayer player, IAsyncContext asyncContext) =>
            asyncContext == null || asyncContext.CreateRef(player) ? new AsyncPlayer(player, asyncContext) : null;

        public static IVehicle ToAsync(this IVehicle vehicle, IAsyncContext asyncContext) =>
            asyncContext == null || asyncContext.CreateRef(vehicle) ? new AsyncVehicle(vehicle, asyncContext) : null;

        public static ICheckpoint ToAsync(this ICheckpoint checkpoint, IAsyncContext asyncContext) =>
            asyncContext == null || asyncContext.CreateRef(checkpoint) ? new AsyncCheckpoint(checkpoint, asyncContext) : null;

        public static IColShape ToAsync(this IColShape colShape, IAsyncContext asyncContext) =>
            asyncContext == null || asyncContext.CreateRef(colShape) ? new AsyncColShape(colShape, asyncContext) : null;

        public static IBlip ToAsync(this IBlip blip, IAsyncContext asyncContext) =>
            asyncContext == null || asyncContext.CreateRef(blip) ? new AsyncBlip(blip, asyncContext) : null;

        public static IVoiceChannel ToAsync(this IVoiceChannel voiceChannel, IAsyncContext asyncContext) =>
            asyncContext == null || asyncContext.CreateRef(voiceChannel) ? new AsyncVoiceChannel(voiceChannel, asyncContext) : null;

        public static IPlayer ToAsync(this IPlayer player) => new AsyncPlayer(player, null);

        public static IVehicle ToAsync(this IVehicle vehicle) => new AsyncVehicle(vehicle, null);

        public static ICheckpoint ToAsync(this ICheckpoint checkpoint) => new AsyncCheckpoint(checkpoint, null);

        public static IColShape ToAsync(this IColShape colShape) => new AsyncColShape(colShape, null);

        public static IBlip ToAsync(this IBlip blip) => new AsyncBlip(blip, null);

        public static IVoiceChannel ToAsync(this IVoiceChannel voiceChannel) => new AsyncVoiceChannel(voiceChannel, null);

        public static bool TryToAsync(this IPlayer thisValue, IAsyncContext asyncContext, out IPlayer player)
        {
            if (!asyncContext.CreateRef(thisValue, true))
            {
                player = default;
                return false;
            }
            
            player = new AsyncPlayer(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this IVehicle thisValue, IAsyncContext asyncContext, out IVehicle vehicle)
        {
            if (!asyncContext.CreateRef(thisValue, true))
            {
                vehicle = default;
                return false;
            }

            vehicle = new AsyncVehicle(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this ICheckpoint thisValue, IAsyncContext asyncContext,
            out ICheckpoint checkpoint)
        {
            if (!asyncContext.CreateRef(thisValue, true))
            {
                checkpoint = default;
                return false;
            }

            checkpoint = new AsyncCheckpoint(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this IColShape thisValue, IAsyncContext asyncContext, out IColShape colShape)
        {
            if (!asyncContext.CreateRef(thisValue, true))
            {
                colShape = default;
                return false;
            }

            colShape = new AsyncColShape(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this IBlip thisValue, IAsyncContext asyncContext, out IBlip blip)
        {
            if (!asyncContext.CreateRef(thisValue, true))
            {
                blip = default;
                return false;
            }

            blip = new AsyncBlip(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this IVoiceChannel thisValue, IAsyncContext asyncContext,
            out IVoiceChannel voiceChannel)
        {
            if (!asyncContext.CreateRef(thisValue, true))
            {
                voiceChannel = default;
                return false;
            }

            voiceChannel = new AsyncVoiceChannel(thisValue, asyncContext);
            return true;
        }
    }
}