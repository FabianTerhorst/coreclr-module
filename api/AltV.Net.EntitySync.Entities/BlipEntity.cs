using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync.Entities
{
    //TODO: add entity events to entity sync that only trigger one time for each entity on stream in,
    //TODO: maybe that can be done by data and then resetData and setData on method call with method and parameters, maybe doesnt even work
    public class BlipEntity : Entity
    {
        private int Sprite
        {
            get => TryGetData<int>("sprite", out var value) ? value : default;
            set => SetData("sprite", value);
        }

        private int Alpha
        {
            get => TryGetData<int>("alpha", out var value) ? value : default;
            set => SetData("alpha", value);
        }

        private int Name
        {
            get => TryGetData<int>("name", out var value) ? value : default;
            set => SetData("name", value);
        }

        /*
    public asMissionCreator: boolean;
    public bright: boolean;
    public category: number;
    public color: number;
    public crewIndicatorVisible: boolean;
    public flashInterval: number;
    public flashTimer: number;
    public flashes: boolean;
    public flashesAlternate: boolean;
    public friendIndicatorVisible: boolean;
    public friendly: boolean;
    public gxtName: string;
    public heading: number;
    public headingIndicatorVisible: boolean;
    public highDetail: boolean;
    public number: number;
    public outlineIndicatorVisible: boolean;
    public priority: number;
    public pulse: boolean;
    public route: boolean;
    public routeColor: number;
    public scale: number;
    public secondaryColor: number;
    public shortRange: boolean;
    public showCone: boolean;
    public shrinked: boolean;
    public tickVisible: boolean;
         */

        public BlipEntity(Vector3 position, int dimension, uint range) : base((ulong) EntityType.Blip, position,
            dimension, range)
        {
        }

        public BlipEntity(Vector3 position, int dimension, uint range, IDictionary<string, object> data) : base(
            (ulong) EntityType.Blip, position, dimension, range, data)
        {
        }
    }
}