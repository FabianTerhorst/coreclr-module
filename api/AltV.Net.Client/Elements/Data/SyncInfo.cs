using System.Runtime.InteropServices;
using AltV.Net.Data;

namespace AltV.Net.Client.Elements.Data;


[StructLayout(LayoutKind.Sequential)]
internal struct SyncInfoInternal
{
    public byte Active;
    public uint ReceivedTick;
    public uint FullyReceivedTick;
    public uint SendTick;
    public uint AckedSendTick;
    public ushort PropertyCount;
    public byte ComponentCount;
    public IntPtr PropertyUpdateCount;
    public IntPtr PropertyUpdateTicks;

    public uint[][] GetPropertyUpdateTicks()
    {
        if (ComponentCount == 0)
        {
            return default;
        }

        var value = PropertyUpdateTicks;
        var values = new uint[ComponentCount][];

        /*var buffer = new byte[4];

        for (var i = 0; i < values.Length; i++)
        {
            values[i] = UIntArray.ReadUInt32(buffer, value);
            value += UIntArray.UInt32Size;
        }*/

        return values;
    }

    public SyncInfo ToPublic()
    {
        return new SyncInfo(
            Active,
            ReceivedTick,
            FullyReceivedTick,
            SendTick,
            AckedSendTick,
            PropertyCount,
            ComponentCount,
            GetPropertyUpdateTicks());
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct SyncInfo : IEquatable<SyncInfo>
{
    public byte Active;
    public uint ReceivedTick;
    public uint FullyReceivedTick;
    public uint SendTick;
    public uint AckedSendTick;
    public ushort PropertyCount;
    public byte ComponentCount;
    public uint[][] PropertyUpdateTicks;

    public SyncInfo(byte active, uint receivedTick, uint fullyReceivedTick, uint sendTick, uint ackedSendTick, ushort propertyCount, byte componentCount, uint[][] propertyUpdateTicks)
    {
        Active = active;
        ReceivedTick = receivedTick;
        FullyReceivedTick = fullyReceivedTick;
        SendTick = sendTick;
        AckedSendTick = ackedSendTick;
        PropertyCount = propertyCount;
        ComponentCount = componentCount;
        PropertyUpdateTicks = propertyUpdateTicks;
    }

    public bool Equals(SyncInfo other)
    {
        return Active == other.Active && ReceivedTick == other.ReceivedTick && FullyReceivedTick == other.FullyReceivedTick && SendTick == other.SendTick && AckedSendTick == other.AckedSendTick && PropertyCount == other.PropertyCount && ComponentCount == other.ComponentCount && PropertyUpdateTicks.Equals(other.PropertyUpdateTicks);
    }

    public override bool Equals(object obj)
    {
        return obj is SyncInfo other && Equals(other);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Active);
        hashCode.Add(ReceivedTick);
        hashCode.Add(FullyReceivedTick);
        hashCode.Add(SendTick);
        hashCode.Add(AckedSendTick);
        hashCode.Add(PropertyCount);
        hashCode.Add(ComponentCount);
        hashCode.Add(PropertyUpdateTicks);
        return hashCode.ToHashCode();
    }
}