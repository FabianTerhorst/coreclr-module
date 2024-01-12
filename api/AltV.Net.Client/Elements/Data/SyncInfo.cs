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

    private uint[] GetCompPropertySize()
    {
        var value = PropertyUpdateCount;
        var values = new uint[ComponentCount];
        var buffer = new byte[4];

        for (var i = 0; i < values.Length; i++)
        {
            values[i] = UIntArray.ReadUInt32(buffer, value);
            value += UIntArray.UInt32Size;
        }

        return values;
    }

    private uint[][] GetPropertyUpdateTicks()
    {
        if (ComponentCount == 0)
        {
            return default;
        }

        var compPropertySize = GetCompPropertySize();

        uint[][] result = new uint[ComponentCount][];

        for (var i = 0; i < ComponentCount; i++)
        {
            result[i] = new uint[compPropertySize[i]];

            for (var j = 0; j < compPropertySize[i]; j++)
            {
                // Calculate the index in the one-dimensional array
                var index = i * (int)compPropertySize[i] + j;

                // Use Marshal to read the value at the specified index
                result[i][j] = (uint)Marshal.PtrToStructure(PropertyUpdateTicks + index * sizeof(uint), typeof(uint));
            }
        }

        return result;
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