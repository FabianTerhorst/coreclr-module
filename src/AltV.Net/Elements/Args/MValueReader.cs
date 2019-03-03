using System.Collections.Generic;
using System.IO;
using AltV.Net.Native;

namespace AltV.Net.Elements.Args
{
    internal class MValueReader : IMValueReader
    {
        private interface IReadableMValue
        {
            MValueArrayBuffer MValueArrayBuffer { get; }

            MValue GetNext();
        }

        private struct MValueArrayReader : IReadableMValue
        {
            public MValueArrayBuffer MValueArrayBuffer { get; }

            public MValueArrayReader(MValueArrayBuffer mValueArrayBuffer)
            {
                MValueArrayBuffer = mValueArrayBuffer;
            }

            public MValue GetNext()
            {
                return MValueArrayBuffer.GetNext();
            }
        }

        private struct MValueObjectReader : IReadableMValue
        {
            public StringViewArray StringViewArray;
            public MValueArrayBuffer MValueArrayBuffer { get; }

            public MValueObjectReader(StringViewArray stringViewArray, MValueArrayBuffer mValueArrayBuffer)
            {
                StringViewArray = stringViewArray;
                MValueArrayBuffer = mValueArrayBuffer;
            }

            public MValue GetNext()
            {
                return MValueArrayBuffer.GetNext();
            }
        }

        private struct MValueStartReader : IReadableMValue
        {
            public MValueArrayBuffer MValueArrayBuffer { get; }

            private MValue mValue;

            public MValueStartReader(ref MValue mValue)
            {
                this.mValue = mValue;
                MValueArrayBuffer = new MValueArrayBuffer();
            }

            public MValue GetNext()
            {
                return mValue;
            }
        }

        private bool insideObject = false;

        private readonly Stack<IReadableMValue> currents = new Stack<IReadableMValue>();

        // Temp values for faster access

        private IReadableMValue readableMValue;

        public MValueReader(ref MValue mValue)
        {
            readableMValue = new MValueStartReader(ref mValue);
        }

        public void BeginObject()
        {
            CheckObject();
            var mValue = readableMValue.GetNext();

            if (mValue.type != MValue.Type.DICT)
            {
                return;
            }

            var stringViewArray = StringViewArray.Nil;
            var valueArrayRef = MValueArray.Nil;
            AltVNative.MValueGet.MValue_GetDict(ref mValue, ref stringViewArray, ref valueArrayRef);
            readableMValue = new MValueObjectReader(stringViewArray, valueArrayRef.Reader());
            currents.Push(readableMValue);
            insideObject = true;
        }

        public void EndObject()
        {
            CheckObject();
            currents.Pop(); // Pop mValueObject we already have
            insideObject = currents.TryPop(out readableMValue);
        }

        public void BeginArray()
        {
            CheckObject();
            var mValue = readableMValue.GetNext();

            if (mValue.type != MValue.Type.LIST)
            {
                return;
            }

            var valueArrayRef = MValueArray.Nil;
            AltVNative.MValueGet.MValue_GetList(ref mValue, ref valueArrayRef);
            readableMValue = new MValueArrayReader(valueArrayRef.Reader());
            currents.Push(readableMValue);
            insideObject = true;
        }

        public void EndArray()
        {
            CheckObject();
            currents.Pop(); // Pop mValueObject we already have
            insideObject = currents.TryPop(out readableMValue);
        }

        private void CheckObject()
        {
            if (!insideObject)
            {
                throw new InvalidDataException("Not inside a object or array");
            }
        }

        private void CheckName()
        {
            // Check if we have more values then names
            if (readableMValue.MValueArrayBuffer.size > ((MValueObjectReader) readableMValue).StringViewArray.size)
            {
                throw new InvalidDataException("Expect a NextValue call, but tried to read a name instead");
            }
        }

        private void CheckValue()
        {
            if (!(readableMValue is MValueObjectReader mValueObjectReader)) return;
            // Check if we have more names then values
            if (readableMValue.MValueArrayBuffer.size < mValueObjectReader.StringViewArray.size)
            {
                throw new InvalidDataException("Expect a NextName() call, but tried to read a value instead");
            }
        }

        public bool HasNext()
        {
            CheckObject();
            switch (readableMValue)
            {
                case MValueObjectReader mValueObjectReader:
                    return mValueObjectReader.StringViewArray.size > 0 &&
                           mValueObjectReader.MValueArrayBuffer.HasNext();
                default:
                    return readableMValue.MValueArrayBuffer.HasNext();
            }
        }

        public string NextName()
        {
            CheckObject();
            if (!(readableMValue is MValueObjectReader))
            {
                throw new InvalidDataException("Not inside a object");
            }

            CheckName();

            return ((MValueObjectReader) readableMValue).StringViewArray.GetNext();
        }

        public void SkipName()
        {
            CheckObject();
            if (!(readableMValue is MValueObjectReader))
            {
                throw new InvalidDataException("Not inside a object");
            }

            CheckName();

            ((MValueObjectReader) readableMValue).StringViewArray.SkipValue();
        }

        public bool NextBool()
        {
            CheckObject();
            CheckValue();
            if (!readableMValue.MValueArrayBuffer.GetNext(out bool value))
            {
                throw new InvalidDataException(
                    $"Expected a bool but found a {readableMValue.MValueArrayBuffer.GePreviousType()}");
            }

            return value;
        }

        public int NextInt()
        {
            CheckObject();
            CheckValue();
            if (!readableMValue.MValueArrayBuffer.GetNext(out int value))
            {
                throw new InvalidDataException(
                    $"Expected a int but found a {readableMValue.MValueArrayBuffer.GePreviousType()}");
            }

            return value;
        }

        public long NextLong()
        {
            CheckObject();
            CheckValue();
            if (!readableMValue.MValueArrayBuffer.GetNext(out long value))
            {
                throw new InvalidDataException(
                    $"Expected a long but found a {readableMValue.MValueArrayBuffer.GePreviousType()}");
            }

            return value;
        }

        public uint NextUInt()
        {
            CheckObject();
            CheckValue();
            if (!readableMValue.MValueArrayBuffer.GetNext(out uint value))
            {
                throw new InvalidDataException(
                    $"Expected a uint but found a {readableMValue.MValueArrayBuffer.GePreviousType()}");
            }

            return value;
        }

        public ulong NextULong()
        {
            CheckObject();
            CheckValue();
            if (!readableMValue.MValueArrayBuffer.GetNext(out ulong value))
            {
                throw new InvalidDataException(
                    $"Expected a ulong but found a {readableMValue.MValueArrayBuffer.GePreviousType()}");
            }

            return value;
        }

        public double NextDouble()
        {
            CheckObject();
            CheckValue();
            if (!readableMValue.MValueArrayBuffer.GetNext(out double value))
            {
                throw new InvalidDataException(
                    $"Expected a double but found a {readableMValue.MValueArrayBuffer.GePreviousType()}");
            }

            return value;
        }

        public string NextString()
        {
            CheckObject();
            CheckValue();
            if (!readableMValue.MValueArrayBuffer.GetNext(out string value))
            {
                throw new InvalidDataException(
                    $"Expected a string but found a {readableMValue.MValueArrayBuffer.GePreviousType()}");
            }

            return value;
        }

        public void SkipValue()
        {
            CheckObject();
            CheckValue();
            readableMValue.MValueArrayBuffer.SkipValue();
        }
    }
}