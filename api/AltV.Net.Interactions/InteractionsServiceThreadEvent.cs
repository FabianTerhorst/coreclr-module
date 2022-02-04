namespace AltV.Net.Interactions;

public struct InteractionsServiceThreadEvent
{
    public readonly byte EventType;

    public readonly object Data;

    public InteractionsServiceThreadEvent(byte eventType, object data)
    {
        this.EventType = eventType;
        this.Data = data;
    }
}