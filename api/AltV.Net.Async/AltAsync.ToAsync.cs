using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static IPlayer ToAsync(this IPlayer player, IAsyncContext asyncContext) =>
            asyncContext.CreateRef(player) ? new AsyncPlayer<IPlayer>(player, asyncContext) : null;

        public static IVehicle ToAsync(this IVehicle vehicle, IAsyncContext asyncContext) =>
            asyncContext.CreateRef(vehicle) ? new AsyncVehicle<IVehicle>(vehicle, asyncContext) : null;

        public static ICheckpoint ToAsync(this ICheckpoint checkpoint, IAsyncContext asyncContext) =>
            asyncContext.CreateRef(checkpoint) ? new AsyncCheckpoint<ICheckpoint>(checkpoint, asyncContext) : null;

        public static IColShape ToAsync(this IColShape colShape, IAsyncContext asyncContext) =>
            asyncContext.CreateRef(colShape) ? new AsyncColShape<IColShape>(colShape, asyncContext) : null;

        public static IBlip ToAsync(this IBlip blip, IAsyncContext asyncContext) =>
            asyncContext.CreateRef(blip) ? new AsyncBlip<IBlip>(blip, asyncContext) : null;

        public static IVoiceChannel ToAsync(this IVoiceChannel voiceChannel, IAsyncContext asyncContext) =>
            asyncContext.CreateRef(voiceChannel) ? new AsyncVoiceChannel<IVoiceChannel>(voiceChannel, asyncContext) : null;

        public static bool TryToAsync(this IPlayer thisValue, IAsyncContext asyncContext, out IPlayer player)
        {
            if (!asyncContext.CreateRef(thisValue, true))
            {
                player = default;
                return false;
            }
            
            player = new AsyncPlayer<IPlayer>(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this IVehicle thisValue, IAsyncContext asyncContext, out IVehicle vehicle)
        {
            if (!asyncContext.CreateRef(thisValue, true))
            {
                vehicle = default;
                return false;
            }

            vehicle = new AsyncVehicle<IVehicle>(thisValue, asyncContext);
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

            checkpoint = new AsyncCheckpoint<ICheckpoint>(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this IColShape thisValue, IAsyncContext asyncContext, out IColShape colShape)
        {
            if (!asyncContext.CreateRef(thisValue, true))
            {
                colShape = default;
                return false;
            }

            colShape = new AsyncColShape<IColShape>(thisValue, asyncContext);
            return true;
        }

        public static bool TryToAsync(this IBlip thisValue, IAsyncContext asyncContext, out IBlip blip)
        {
            if (!asyncContext.CreateRef(thisValue, true))
            {
                blip = default;
                return false;
            }

            blip = new AsyncBlip<IBlip>(thisValue, asyncContext);
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

            voiceChannel = new AsyncVoiceChannel<IVoiceChannel>(thisValue, asyncContext);
            return true;
        }
    }
}