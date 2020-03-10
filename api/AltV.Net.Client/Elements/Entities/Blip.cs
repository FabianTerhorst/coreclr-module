using System.Numerics;
using WebAssembly;
using WebAssembly.Core;

namespace AltV.Net.Client.Elements.Entities
{
    public class Blip : WorldObject, IBlip
    {
        public int Alpha
        {
            get { return (int)jsObject.GetObjectProperty("alpha"); }
            set { jsObject.SetObjectProperty("x", value); }
        }
        public bool AsMissionCreator
        {
            get { return (bool)jsObject.GetObjectProperty("asMissionCreator"); }
            set { jsObject.SetObjectProperty("asMissionCreator", value); }
        }
        public bool Bright
        {
            get { return (bool)jsObject.GetObjectProperty("bright"); }
            set { jsObject.SetObjectProperty("bright", value); }
        }
        public int Category
        {
            get { return (int)jsObject.GetObjectProperty("category"); }
            set { jsObject.SetObjectProperty("category", value); }
        }
        public int Color
        {
            get { return (int)jsObject.GetObjectProperty("color"); }
            set { jsObject.SetObjectProperty("color", value); }
        }
        public bool CrewIndicatorVisible
        {
            get { return (bool)jsObject.GetObjectProperty("crewIndicatorVisible"); }
            set { jsObject.SetObjectProperty("crewIndicatorVisible", value); }
        }
        public int FlashInterval
        {
            get { return (int)jsObject.GetObjectProperty("flashInterval"); }
            set { jsObject.SetObjectProperty("flashInterval", value); }
        }
        public int FlashTimer
        {
            get { return (int)jsObject.GetObjectProperty("flashTimer"); }
            set { jsObject.SetObjectProperty("flashTimer", value); }
        }
        public bool Flashes
        {
            get { return (bool)jsObject.GetObjectProperty("flashes"); }
            set { jsObject.SetObjectProperty("flashes", value); }
        }
        public bool FlashesAlternate
        {
            get { return (bool)jsObject.GetObjectProperty("flashesAlternate"); }
            set { jsObject.SetObjectProperty("flashesAlternate", value); }
        }
        public bool FriendIndicatorVisible
        {
            get { return (bool)jsObject.GetObjectProperty("friendIndicatorVisible"); }
            set { jsObject.SetObjectProperty("friendIndicatorVisible", value); }
        }
        public bool Friendly
        {
            get { return (bool)jsObject.GetObjectProperty("friendly"); }
            set { jsObject.SetObjectProperty("friendly", value); }
        }
        public string GxtName
        {
            get { return (string)jsObject.GetObjectProperty("gxtName"); }
            set { jsObject.SetObjectProperty("gxtName", value); }
        }
        public float Heading
        {
            get { return (float)jsObject.GetObjectProperty("heading"); }
            set { jsObject.SetObjectProperty("heading", value); }
        }
        public bool HeadingIndicatorVisible
        {
            get { return (bool)jsObject.GetObjectProperty("headingIndicatorVisible"); }
            set { jsObject.SetObjectProperty("headingIndicatorVisible", value); }
        }
        public bool HighDetail
        {
            get { return (bool)jsObject.GetObjectProperty("highDetail"); }
            set { jsObject.SetObjectProperty("highDetail", value); }
        }
        public string Name
        {
            get { return (string)jsObject.GetObjectProperty("name"); }
            set { jsObject.SetObjectProperty("name", value); }
        }
        public int Number
        {
            get { return (int)jsObject.GetObjectProperty("number"); }
            set { jsObject.SetObjectProperty("number", value); }
        }
        public bool OutlineIndicatorVisible
        {
            get { return (bool)jsObject.GetObjectProperty("outlineIndicatorVisible"); }
            set { jsObject.SetObjectProperty("outlineIndicatorVisible", value); }
        }
        public int Priority
        {
            get { return (int)jsObject.GetObjectProperty("priority"); }
            set { jsObject.SetObjectProperty("priority", value); }
        }
        public bool Pulse
        {
            get { return (bool)jsObject.GetObjectProperty("pulse"); }
            set { jsObject.SetObjectProperty("pulse", value); }
        }        
        public bool Route
        {
            get { return (bool)jsObject.GetObjectProperty("route"); }
            set { jsObject.SetObjectProperty("route", value); }
        }
        public int RouteColor
        {
            get { return (int)jsObject.GetObjectProperty("routeColor"); }
            set { jsObject.SetObjectProperty("routeColor", value); }
        }
        public float Scale
        {
            get { return (float)jsObject.GetObjectProperty("scale"); }
            set { jsObject.SetObjectProperty("scale", value); }
        }
        public int SecondaryColor
        {
            get { return (int)jsObject.GetObjectProperty("secondaryColor"); }
            set { jsObject.SetObjectProperty("secondaryColor", value); }
        }
        public bool ShortRange
        {
            get { return (bool)jsObject.GetObjectProperty("shortRange"); }
            set { jsObject.SetObjectProperty("shortRange", value); }
        }
        public bool ShowCone
        {
            get { return (bool)jsObject.GetObjectProperty("showCone"); }
            set { jsObject.SetObjectProperty("showCone", value); }
        }
        public bool Shrinked
        {
            get { return (bool)jsObject.GetObjectProperty("shrinked"); }
            set { jsObject.SetObjectProperty("shrinked", value); }
        }        
        public int Sprite
        {
            get { return (int)jsObject.GetObjectProperty("sprite"); }
            set { jsObject.SetObjectProperty("sprite", value); }
        }
        public bool TickVisible
        {
            get { return (bool)jsObject.GetObjectProperty("tickVisible"); }
            set { jsObject.SetObjectProperty("tickVisible", value); }
        }
        public Blip(JSObject jsObject): base(jsObject){}
        public void Fade(int opacity, int number)
        {
            jsObject.Invoke("fade", opacity, number);
        }
    }
}
