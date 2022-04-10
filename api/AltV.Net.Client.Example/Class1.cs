using AltV.Net.Data;

namespace AltV.Net.Client.Example
{
    public class Main : Resource
    {
        private bool drawNametags = false;
        public override void OnStart()
        {
            Alt.LogInfo("Client Started!");

            Alt.OnTick += () =>
            {
                if (drawNametags) DrawNametags();
            };
            
            Alt.OnKeyDown += (key) =>
            {
                switch (key)
                {
                    case ConsoleKey.X:
                        drawNametags = !drawNametags;
                        break;
                }
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
                var vector = Alt.Natives.GetEntityVelocity((int) entity);
                var frameTime = Alt.Natives.GetFrameTime();
                
                Alt.Natives.SetDrawOrigin(pos.X + vector.X * frameTime, pos.Y + vector.Y * frameTime, pos.Z, 0);
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