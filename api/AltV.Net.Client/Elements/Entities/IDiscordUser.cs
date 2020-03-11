namespace AltV.Net.Client.Elements.Entities
{
    public interface IDiscordUser
    {
        string Id { get; }
        string Name { get; }
        string Discriminator { get; }
        string Avatar { get; }
    }
}