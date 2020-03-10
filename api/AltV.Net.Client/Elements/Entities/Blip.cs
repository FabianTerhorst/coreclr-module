using WebAssembly;

namespace AltV.Net.Client.Elements.Entities
{
    public class Blip : WorldObject, IBlip
    {
        public int Alpha
        {
            get => (int) jsObject.GetObjectProperty("alpha");
            set => jsObject.SetObjectProperty("x", value);
        }

        public bool AsMissionCreator
        {
            get => (bool) jsObject.GetObjectProperty("asMissionCreator");
            set => jsObject.SetObjectProperty("asMissionCreator", value);
        }

        public bool Bright
        {
            get => (bool) jsObject.GetObjectProperty("bright");
            set => jsObject.SetObjectProperty("bright", value);
        }

        public int Category
        {
            get => (int) jsObject.GetObjectProperty("category");
            set => jsObject.SetObjectProperty("category", value);
        }

        public int Color
        {
            get => (int) jsObject.GetObjectProperty("color");
            set => jsObject.SetObjectProperty("color", value);
        }

        public bool CrewIndicatorVisible
        {
            get => (bool) jsObject.GetObjectProperty("crewIndicatorVisible");
            set => jsObject.SetObjectProperty("crewIndicatorVisible", value);
        }

        public int FlashInterval
        {
            get => (int) jsObject.GetObjectProperty("flashInterval");
            set => jsObject.SetObjectProperty("flashInterval", value);
        }

        public int FlashTimer
        {
            get => (int) jsObject.GetObjectProperty("flashTimer");
            set => jsObject.SetObjectProperty("flashTimer", value);
        }

        public bool Flashes
        {
            get => (bool) jsObject.GetObjectProperty("flashes");
            set => jsObject.SetObjectProperty("flashes", value);
        }

        public bool FlashesAlternate
        {
            get => (bool) jsObject.GetObjectProperty("flashesAlternate");
            set => jsObject.SetObjectProperty("flashesAlternate", value);
        }

        public bool FriendIndicatorVisible
        {
            get => (bool) jsObject.GetObjectProperty("friendIndicatorVisible");
            set => jsObject.SetObjectProperty("friendIndicatorVisible", value);
        }

        public bool Friendly
        {
            get => (bool) jsObject.GetObjectProperty("friendly");
            set => jsObject.SetObjectProperty("friendly", value);
        }

        public string GxtName
        {
            get => (string) jsObject.GetObjectProperty("gxtName");
            set => jsObject.SetObjectProperty("gxtName", value);
        }

        public float Heading
        {
            get => (float) jsObject.GetObjectProperty("heading");
            set => jsObject.SetObjectProperty("heading", value);
        }

        public bool HeadingIndicatorVisible
        {
            get => (bool) jsObject.GetObjectProperty("headingIndicatorVisible");
            set => jsObject.SetObjectProperty("headingIndicatorVisible", value);
        }

        public bool HighDetail
        {
            get => (bool) jsObject.GetObjectProperty("highDetail");
            set => jsObject.SetObjectProperty("highDetail", value);
        }

        public string Name
        {
            get => (string) jsObject.GetObjectProperty("name");
            set => jsObject.SetObjectProperty("name", value);
        }

        public int Number
        {
            get => (int) jsObject.GetObjectProperty("number");
            set => jsObject.SetObjectProperty("number", value);
        }

        public bool OutlineIndicatorVisible
        {
            get => (bool) jsObject.GetObjectProperty("outlineIndicatorVisible");
            set => jsObject.SetObjectProperty("outlineIndicatorVisible", value);
        }

        public int Priority
        {
            get => (int) jsObject.GetObjectProperty("priority");
            set => jsObject.SetObjectProperty("priority", value);
        }

        public bool Pulse
        {
            get => (bool) jsObject.GetObjectProperty("pulse");
            set => jsObject.SetObjectProperty("pulse", value);
        }

        public bool Route
        {
            get => (bool) jsObject.GetObjectProperty("route");
            set => jsObject.SetObjectProperty("route", value);
        }

        public int RouteColor
        {
            get => (int) jsObject.GetObjectProperty("routeColor");
            set => jsObject.SetObjectProperty("routeColor", value);
        }

        public float Scale
        {
            get => (float) jsObject.GetObjectProperty("scale");
            set => jsObject.SetObjectProperty("scale", value);
        }

        public int SecondaryColor
        {
            get => (int) jsObject.GetObjectProperty("secondaryColor");
            set => jsObject.SetObjectProperty("secondaryColor", value);
        }

        public bool ShortRange
        {
            get => (bool) jsObject.GetObjectProperty("shortRange");
            set => jsObject.SetObjectProperty("shortRange", value);
        }

        public bool ShowCone
        {
            get => (bool) jsObject.GetObjectProperty("showCone");
            set => jsObject.SetObjectProperty("showCone", value);
        }

        public bool Shrinked
        {
            get => (bool) jsObject.GetObjectProperty("shrinked");
            set => jsObject.SetObjectProperty("shrinked", value);
        }

        public int Sprite
        {
            get => (int) jsObject.GetObjectProperty("sprite");
            set => jsObject.SetObjectProperty("sprite", value);
        }

        public bool TickVisible
        {
            get => (bool) jsObject.GetObjectProperty("tickVisible");
            set => jsObject.SetObjectProperty("tickVisible", value);
        }

        public Blip(JSObject jsObject) : base(jsObject)
        {
        }

        public void Fade(int opacity, int duration)
        {
            jsObject.Invoke("fade", opacity, duration);
        }
    }
}