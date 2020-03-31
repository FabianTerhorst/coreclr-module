using WebAssembly;

namespace AltV.Net.Client.Elements.Entities
{
    public class DiscordUser : IDiscordUser
    {
        private readonly JSObject jsObject;

        public DiscordUser(JSObject jsObject)
        {
            this.jsObject = jsObject;
        }

        public string Id => (string) jsObject.GetObjectProperty("id");

        public string Name => (string) jsObject.GetObjectProperty("name");

        public string Discriminator => (string) jsObject.GetObjectProperty("discriminator");

        public string Avatar => (string) jsObject.GetObjectProperty("avatar");
    }
}