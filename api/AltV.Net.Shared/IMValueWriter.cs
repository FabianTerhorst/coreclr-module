using System.Collections;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

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

        void Value(float value);

        void Value(double value);

        void Value(string value);

        void Value(ISharedBaseObject value);

        void Value(ICollection value);

        void Value(IWritable value);

        void Value(Position value);

        void Value(Rotation value);

        void Value(Rgba value);

        void Value(Vector3 value);

        void Value(Vector2 value);
    }
}