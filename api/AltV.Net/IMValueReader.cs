using AltV.Net.Elements.Args;

namespace AltV.Net
{
    public interface IMValueReader
    {
        void BeginObject();
        
        void EndObject();
        
        void BeginArray();
        
        void EndArray();

        bool HasNext();

        string NextName();

        void SkipName();

        bool NextBool();

        int NextInt();

        long NextLong();

        uint NextUInt();

        ulong NextULong();

        double NextDouble();

        string NextString();

        void SkipValue();

        MValueReaderToken Peek();
    }
}