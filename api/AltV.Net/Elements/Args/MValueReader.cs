using System;
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

            void Dispose();
        }

        private struct MValueArrayReader : IReadableMValue
        {
            public MValueArray MValueArray { get; }
            
            public MValueArrayBuffer MValueArrayBuffer { get; }

            public MValueArrayReader(MValueArray mValueArray)
            {
                MValueArray = mValueArray;
                MValueArrayBuffer = mValueArray.Reader();
            }

            public MValue GetNext()
            {
                return MValueArrayBuffer.GetNext();
            }

            public void Dispose()
            {
                MValueArray.Dispose();
            }
        }

        private struct MValueObjectReader : IReadableMValue
        {
            public StringArray StringArray { get; }
            public MValueArray MValueArray { get; }
            public MValueArrayBuffer MValueArrayBuffer { get; }
            public IntPtr StringArrayOffset;

            public MValueObjectReader(StringArray stringArray, MValueArray mValueArray)
            {
                StringArray = stringArray;
                MValueArray = mValueArray;
                MValueArrayBuffer = mValueArray.Reader();
                StringArrayOffset = StringArray.data;
            }

            public MValue GetNext()
            {
                return MValueArrayBuffer.GetNext();
            }

            public string GetNextName()
            {
                return StringArray.GetNextWithOffset(ref StringArrayOffset);
            }
            
            public void SkipNextName()
            {
                StringArray.SkipValueWithOffset(ref StringArrayOffset);
            }

            public void Dispose()
            {
                StringArray.Dispose();
                MValueArray.Dispose();
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

            public void Dispose()
            {
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

            var stringArray = StringArray.Nil;
            var valueArrayRef = MValueArray.Nil;
            AltNative.MValueGet.MValue_GetDict(ref mValue, ref stringArray, ref valueArrayRef);
            readableMValue = new MValueObjectReader(stringArray, valueArrayRef);
            currents.Push(readableMValue);
            insideObject = true;
        }

        public void EndObject()
        {
            CheckObject();
            currents.Pop().Dispose(); // Pop mValueObject we already have
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
            AltNative.MValueGet.MValue_GetList(ref mValue, ref valueArrayRef);
            readableMValue = new MValueArrayReader(valueArrayRef);
            currents.Push(readableMValue);
            insideObject = true;
        }

        public void EndArray()
        {
            CheckObject();
            currents.Pop().Dispose(); // Pop mValueObject we already have
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
            if (readableMValue.MValueArrayBuffer.size > ((MValueObjectReader) readableMValue).StringArray.size)
            {
                throw new InvalidDataException("Expect a NextValue call, but tried to read a name instead");
            }
        }

        private void CheckValue()
        {
            if (!(readableMValue is MValueObjectReader mValueObjectReader)) return;
            // Check if we have more names then values
            if (readableMValue.MValueArrayBuffer.size < mValueObjectReader.StringArray.size)
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
                    return mValueObjectReader.StringArray.size > 0 &&
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

            return ((MValueObjectReader) readableMValue).GetNextName();
        }

        public void SkipName()
        {
            CheckObject();
            if (!(readableMValue is MValueObjectReader))
            {
                throw new InvalidDataException("Not inside a object");
            }

            CheckName();

            ((MValueObjectReader) readableMValue).SkipNextName();
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