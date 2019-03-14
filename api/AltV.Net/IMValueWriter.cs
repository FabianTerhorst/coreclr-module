using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IMValueWriter
    {
        void BeginObject();

        void EndObject();

        void BeginArray();

        void EndArray();

        void Name(string name);

        void Value(bool value);

        void Value(int value);

        void Value(long value);

        void Value(uint value);

        void Value(ulong value);

        void Value(double value);

        void Value(string value);

        void Value(ICheckpoint value);

        void Value(IBlip value);

        void Value(IVehicle value);

        void Value(IPlayer value);
    }
}