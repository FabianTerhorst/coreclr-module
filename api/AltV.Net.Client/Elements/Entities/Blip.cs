using System.Numerics;
using WebAssembly;

namespace AltV.Net.Client.Elements.Entities
{
    public class Blip : WorldObject, IBlip
    {
        public int Alpha
        {
            get { return (int)jsObject.GetObjectProperty("alpha"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("alpha", value); }
        }
        public bool AsMissionCreator
        {
            get { return (bool)jsObject.GetObjectProperty("asMissionCreator"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("asMissionCreator", value); }
        }
        public bool Bright
        {
            get { return (bool)jsObject.GetObjectProperty("bright"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("bright", value); }
        }
        public int Category
        {
            get { return (int)jsObject.GetObjectProperty("category"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("category", value); }
        }
        public int Color
        {
            get { return (int)jsObject.GetObjectProperty("color"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("color", value); }
        }
        public bool CrewIndicatorVisible
        {
            get { return (bool)jsObject.GetObjectProperty("crewIndicatorVisible"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("crewIndicatorVisible", value); }
        }
        public int FlashInterval
        {
            get { return (int)jsObject.GetObjectProperty("flashInterval"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("flashInterval", value); }
        }
        public int FlashTimer
        {
            get { return (int)jsObject.GetObjectProperty("flashTimer"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("flashTimer", value); }
        }
        public bool Flashes
        {
            get { return (bool)jsObject.GetObjectProperty("flashes"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("flashes", value); }
        }
        public bool FlashesAlternate
        {
            get { return (bool)jsObject.GetObjectProperty("flashesAlternate"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("flashesAlternate", value); }
        }
        public bool FriendIndicatorVisible
        {
            get { return (bool)jsObject.GetObjectProperty("friendIndicatorVisible"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("friendIndicatorVisible", value); }
        }
        public bool Friendly
        {
            get { return (bool)jsObject.GetObjectProperty("friendly"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("friendly", value); }
        }
        public string GxtName
        {
            get { return (string)jsObject.GetObjectProperty("gxtName"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("gxtName", value); }
        }
        public float Heading
        {
            get { return (float)jsObject.GetObjectProperty("heading"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("heading", value); }
        }
        public bool HeadingIndicatorVisible
        {
            get { return (bool)jsObject.GetObjectProperty("headingIndicatorVisible"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("headingIndicatorVisible", value); }
        }
        public bool HighDetail
        {
            get { return (bool)jsObject.GetObjectProperty("highDetail"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("highDetail", value); }
        }
        public string Name
        {
            get { return (string)jsObject.GetObjectProperty("name"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("name", value); }
        }
        public int Number
        {
            get { return (int)jsObject.GetObjectProperty("number"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("number", value); }
        }
        public bool OutlineIndicatorVisible
        {
            get { return (bool)jsObject.GetObjectProperty("outlineIndicatorVisible"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("outlineIndicatorVisible", value); }
        }
        public int Priority
        {
            get { return (int)jsObject.GetObjectProperty("priority"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("priority", value); }
        }
        public bool Pulse
        {
            get { return (bool)jsObject.GetObjectProperty("pulse"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("pulse", value); }
        }        
        public bool Route
        {
            get { return (bool)jsObject.GetObjectProperty("route"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("route", value); }
        }
        public int RouteColor
        {
            get { return (int)jsObject.GetObjectProperty("routeColor"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("routeColor", value); }
        }
        public float Scale
        {
            get { return (float)jsObject.GetObjectProperty("scale"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("scale", value); }
        }
        public int SecondaryColor
        {
            get { return (int)jsObject.GetObjectProperty("secondaryColor"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("secondaryColor", value); }
        }
        public bool ShortRange
        {
            get { return (bool)jsObject.GetObjectProperty("shortRange"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("shortRange", value); }
        }
        public bool ShowCone
        {
            get { return (bool)jsObject.GetObjectProperty("showCone"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("showCone", value); }
        }
        public bool Shrinked
        {
            get { return (bool)jsObject.GetObjectProperty("shrinked"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("shrinked", value); }
        }        
        public int Sprite
        {
            get { return (int)jsObject.GetObjectProperty("sprite"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("sprite", value); }
        }
        public bool TickVisible
        {
            get { return (bool)jsObject.GetObjectProperty("tickVisible"); }
            set { JSObject JsObj = Runtime.NewJSObject(); JsObj.SetObjectProperty("tickVisible", value); }
        }
        public Blip(JSObject jsObject): base(jsObject){}
    }
}
