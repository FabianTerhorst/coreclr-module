namespace AltV.Net.Client.Elements.Data
{
    public struct HttpResponse
    {
        public int StatusCode;
        public string Body;
        public Dictionary<string, string> Headers;
    }
}