using WebAssembly;

namespace AltV.Net.Client.Elements.Entities
{
    public class DiscordUser : IDiscordUser
    {

        private readonly JSObject jsObject;
        public DiscordUser(JSObject jsObject) { this.jsObject = jsObject; }
        public string Id { get { return (string)jsObject.GetObjectProperty("id"); } }
        public string Name { get { return (string)jsObject.GetObjectProperty("name"); } }
        public string Discriminator { get { return (string)jsObject.GetObjectProperty("discriminator"); } }
        public string Avatar { get { return (string)jsObject.GetObjectProperty("avatar"); } }
    }
}
