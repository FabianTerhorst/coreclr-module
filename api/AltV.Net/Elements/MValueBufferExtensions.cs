using AltV.Net.Elements.Args;

namespace AltV.Net.Elements
{
    public static class MValueBufferExtensions
    {
        public static MValueBuffer2 Reader(this IMValueConst[] array)
        {
            return new MValueBuffer2(Alt.Core, array); // todo remove Alt.Core
        }
    }
}