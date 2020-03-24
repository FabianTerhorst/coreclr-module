namespace AltV.Net.Client.Elements.Entities
{
    public interface IBlip : IWorldObject
    {
        int Alpha { get; set; }
        bool AsMissionCreator { get; set; }
        bool Bright { get; set; }
        int Category { get; set; }
        int Color { get; set; }
        bool CrewIndicatorVisible { get; set; }
        int FlashInterval { get; set; }
        int FlashTimer { get; set; }
        bool Flashes { get; set; }
        bool FlashesAlternate { get; set; }
        bool FriendIndicatorVisible { get; set; }
        bool Friendly { get; set; }
        string GxtName { get; set; }
        float Heading { get; set; }
        bool HeadingIndicatorVisible { get; set; }
        bool HighDetail { get; set; }
        string Name { get; set; }
        int Number { get; set; }
        bool OutlineIndicatorVisible { get; set; }
        int Priority { get; set; }
        bool Pulse { get; set; }
        bool Route { get; set; }
        int RouteColor { get; set; }
        float Scale { get; set; }
        int SecondaryColor { get; set; }
        bool ShortRange { get; set; }
        bool ShowCone { get; set; }
        bool Shrinked { get; set; }
        int Sprite { get; set; }
        bool TickVisible { get; set; }
        void Fade(int opacity, int duration);
    }
}