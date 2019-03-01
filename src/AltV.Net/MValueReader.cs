using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using AltV.Net.Native;

namespace AltV.Net
{
    public class MValueReader
    {
        public interface IReadableMValue
        {
            MValueArrayBuffer MValueArrayBuffer { get; }
        }

        public struct MValueArrayReader : IReadableMValue
        {
            public MValueArrayBuffer MValueArrayBuffer { get; }

            public MValueArrayReader(MValueArrayBuffer mValueArrayBuffer)
            {
                MValueArrayBuffer = mValueArrayBuffer;
            }
        }

        public struct MValueObjectReader : IReadableMValue
        {
            public StringViewArray StringViewArray;
            public MValueArrayBuffer MValueArrayBuffer { get; }

            public MValueObjectReader(StringViewArray stringViewArray, MValueArrayBuffer mValueArrayBuffer)
            {
                StringViewArray = stringViewArray;
                MValueArrayBuffer = mValueArrayBuffer;
            }
        }

        private IntPtr data; // Array of MValue's
        private ulong size;

        private bool insideObject = true;

        private readonly Stack<IReadableMValue> currents = new Stack<IReadableMValue>();

        // Temp values for faster access

        private IReadableMValue readableMValue;

        public MValueReader(IntPtr data, ulong size)
        {
            this.data = data;
            this.size = size;
        }

        public void BeginObject()
        {
            MValue mValue;
            if (insideObject)
            {
                switch (readableMValue)
                {
                    case MValueObjectReader mValueObjectReader:
                        mValue = mValueObjectReader.MValueArrayBuffer.GetNext();
                        break;
                    case MValueArrayReader mValueArrayReader:
                        mValue = mValueArrayReader.MValueArrayBuffer.GetNext();
                        break;
                    default:
                        return;
                }
            }
            else
            {
                if (size == 0)
                {
                    return;
                }

                mValue = Marshal.PtrToStructure<MValue>(data);
                data += MValue.Size;
                size--;
            }

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
            currents.Pop(); // Pop mValueObject we already have
            insideObject = currents.TryPop(out readableMValue);
        }

        public void BeginArray()
        {
            MValue mValue;
            if (insideObject)
            {
                mValue = readableMValue.MValueArrayBuffer.GetNext();
            }
            else
            {
                if (size == 0)
                {
                    return;
                }

                mValue = Marshal.PtrToStructure<MValue>(data);
                data += MValue.Size;
                size--;
            }

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

        public bool HasNext()
        {
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

            return ((MValueObjectReader) readableMValue).StringViewArray.GetNext();
        }

        public void SkipName()
        {
            CheckObject();
            if (!(readableMValue is MValueObjectReader))
            {
                throw new InvalidDataException("Not inside a object");
            }

            ((MValueObjectReader) readableMValue).StringViewArray.SkipValue();
        }

        public bool NextBool()
        {
            CheckObject();
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
            readableMValue.MValueArrayBuffer.SkipValue();
        }
    }
}