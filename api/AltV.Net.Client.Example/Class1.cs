using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;

namespace AltV.Net.Client.Example
{
    public class Main : Resource
    {
        private bool drawNametags = false;
        private IWebView webView;
        public override void OnStart()
        {
            Alt.LogInfo("Client Started!");
            webView = Alt.CreateWebView("http://resource/client/html/index.html");

            webView.On("test2", () =>
            {
                Alt.LogInfo("[C#]test2 received");
            });

            Alt.OnTick += () =>
            {
                if (drawNametags) DrawNametags();
            };

            Alt.OnKeyDown += (key) =>
            {
                switch (key)
                {
                    case Key.X:
                        drawNametags = !drawNametags;
                        webView.Emit("test");
                        break;
                    case Key.M:
                        Alt.Log($"HasLocalMeta Test3: {Alt.HasLocalMetaData("test3").ToString()}");
                        Alt.Log($"HasLocalMeta Test: {Alt.HasLocalMetaData("test").ToString()}");
                        Alt.GetLocalMetaData<string>("test", out var meta);
                        Alt.Log($"GetLocalMeta Test: {meta}");
                        break;
                }
            };

            Alt.OnGlobalMetaChange += (key, value, oldValue) =>
            {
                Alt.Log($"{key} changed from {oldValue.ToString()} to {value.ToString()}");
            };

            Alt.OnGlobalSyncedMetaChange += (key, value, oldValue) =>
            {
                Alt.Log($"SYNCED: {key} changed from {oldValue.ToString()} to {value.ToString()}");
            };

            Alt.OnConnectionComplete += () =>
            {
                Alt.Log("Connected!");
            };

            Alt.OnPlayerChangeVehicleSeat += (vehicle, seat, oldSeat) =>
            {
                Alt.Log($"Changed seat from {oldSeat} to {seat} in {vehicle.Id}");
            };

            Alt.OnPlayerLeaveVehicle += (vehicle, seat) =>
            {
                Alt.Log($"Left seat {seat} in {vehicle.Id}");
            };

            Alt.OnLocalMetaChange += (key, value, oldValue) =>
            {
                Alt.Log($"LOCAL META: {key} changed from {oldValue.ToString()} to {value.ToString()}");
            };

            Alt.OnNetOwnerChange += (entity, newOwner, oldOwner) =>
            {
                if (oldOwner == null)
                {
                    Alt.LogInfo("Old owner is null");
                }
                if (newOwner == null)
                {
                    Alt.LogInfo("New owner is null");
                }
                Alt.Log($"Owner changed from {oldOwner?.Id} to {newOwner?.Id} in {entity.Id}");
                Alt.Log($"Netowner changed for {entity.Id}");
            };

            Alt.OnRemoveEntity += (entity) =>
            {
                Alt.Log($"{entity.Id} removed");
            };

            Alt.OnStreamSyncedMetaChange += (entity, key, value, oldValue) =>
            {
                Alt.Log($"STREAM SYNCED META: {key} changed from {oldValue.ToString()} to {value.ToString()}");
            };

            Alt.OnSyncedMetaChange += (entity, key, value, oldValue) =>
            {
                Alt.Log($"SYNCED META: {key} changed from {oldValue.ToString()} to {value.ToString()}");
            };

            Alt.OnTaskChange += (task, newTask) =>
            {
                Alt.Log($"{task} changed to {newTask}");
            };

            Alt.OnWindowFocusChange += (focused) =>
            {
                Alt.Log($"Window focus changed to {focused}");
            };

            Alt.OnWindowResolutionChange += (old, @new) =>
            {
                Alt.Log($"Window resolution changed from {old.X}x{old.Y} to {@new.X}x{@new.Y}");
            };

        }

        public override void OnStop()
        {
            Alt.LogInfo("Client Stopped!");
        }

        private double Distance2D(Position position1, Position position2)
        {
            return Math.Sqrt(Math.Pow(position1.X - position2.X, 2) + Math.Pow(position1.Y - position2.Y, 2));
        }

        public void DrawNametags()
        {
            if (!drawNametags) return;
            foreach (var player in Alt.GetAllPlayers())
            {
                if (!player.Exists) continue;
                if (!player.Spawned) continue;
                if (!Alt.Natives.HasEntityClearLosToEntity(player, Alt.LocalPlayer, 17)) continue;
                var distance = Distance2D(player.Position, Alt.LocalPlayer.Position);
                if (distance > 100) continue;
                var pos = Alt.Natives.GetPedBoneCoords(player, 12844, 0, 0, 0);
                pos.Z += 0.75f;

                var scale = 1 - (0.8 * distance) / 100;
                var fontSize = 0.6 * scale;

                var lineHeight = Alt.Natives.GetRenderedCharacterHeight((float) fontSize, 4);
                var entity = player.IsInVehicle ? player.Vehicle?.ScriptId : player.ScriptId;
                if (entity == null) continue;
                var vector = Alt.Natives.GetEntityVelocity((uint) entity);
                var frameTime = Alt.Natives.GetFrameTime();

                Alt.Natives.SetDrawOrigin(pos.X + vector.X * frameTime, pos.Y + vector.Y * frameTime, pos.Z, false);
                Alt.Natives.BeginTextCommandDisplayText("STRING");
                Alt.Natives.SetTextFont(4);
                Alt.Natives.SetTextScale((float) fontSize, (float) fontSize);
                Alt.Natives.SetTextProportional(true);
                Alt.Natives.SetTextCentre(true);
                Alt.Natives.SetTextColour(255, 255, 255, 255);
                Alt.Natives.SetTextOutline();
                Alt.Natives.AddTextComponentSubstringPlayerName(player.Name);
                Alt.Natives.EndTextCommandDisplayText(0, 0, 0);
            }
        }
    }
}