namespace AltV.Net.NetworkingEntity
{
    public enum StreamingType : byte
    {
        Default,
        DataStreaming,
        EntityStreaming /*TODO: will be implemented later to send entity to client when near range for not sending all entities on connect*/
    }
}