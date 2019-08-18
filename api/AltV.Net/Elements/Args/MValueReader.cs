using System;
using System.Collections.Generic;
using System.IO;
using AltV.Net.Native;

namespace AltV.Net.Elements.Args
{
    //TODO: look into freeing mvaluearray
    internal class MValueReader : IMValueReader
    {
        private interface IReadableMValue
        {
            MValue GetNext();

            void Dispose();

            MValue Peek();

            ulong GetSize();

            bool GetNext(out bool value);

            bool GetNext(out int value);

            bool GetNext(out uint value);

            bool GetNext(out long value);

            bool GetNext(out ulong value);

            bool GetNext(out float value);

            bool GetNext(out double value);

            bool GetNext(out string value);

            MValue.Type GetPreviousType();

            bool HasNext();

            void SkipValue();
        }

        private class MValueArrayReader : IReadableMValue
        {
            private MValueArray mValueArray;

            private MValueArrayBuffer mValueArrayBuffer;

            private ulong size;

            public MValueArrayReader(MValueArray mValueArray)
            {
                this.mValueArray = mValueArray;
                mValueArrayBuffer = mValueArray.Reader();
                size = mValueArrayBuffer.size;
            }

            public MValue GetNext()
            {
                var value = mValueArrayBuffer.GetNext();
                size--;
                return value;
            }

            public bool GetNext(out bool value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out int value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out uint value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out long value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out ulong value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out float value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out double value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out string value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public void Dispose()
            {
                mValueArray.Dispose();
            }

            public MValue Peek()
            {
                return mValueArrayBuffer.Peek();
            }

            public ulong GetSize()
            {
                return size;
            }
            
            public MValue.Type GetPreviousType()
            {
                return mValueArrayBuffer.GetPreviousType();
            }

            public bool HasNext()
            {
                return mValueArrayBuffer.HasNext();
            }

            public void SkipValue()
            {
                mValueArrayBuffer.SkipValue();
            }
        }

        private class MValueObjectReader : IReadableMValue
        {
            private StringArray stringArray;
            private MValueArray mValueArray;
            private MValueArrayBuffer mValueArrayBuffer;
            private IntPtr stringArrayOffset;
            private ulong size;

            public MValueObjectReader(StringArray stringArray, MValueArray mValueArray)
            {
                this.stringArray = stringArray;
                this.mValueArray = mValueArray;
                mValueArrayBuffer = mValueArray.Reader();
                stringArrayOffset = this.stringArray.data;
                size = this.stringArray.size;
            }

            public MValue GetNext()
            {
                return mValueArrayBuffer.GetNext();
            }

            public bool GetNext(out bool value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out int value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out uint value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out long value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out ulong value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out float value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out double value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public bool GetNext(out string value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                size--;
                return result;
            }

            public string GetNextName()
            {
                var value = stringArray.GetNextWithOffset(ref stringArrayOffset);
                size--;
                return value;
            }

            public void SkipNextName()
            {
                stringArray.SkipValueWithOffset(ref stringArrayOffset);
                size--;
            }

            public void Dispose()
            {
                stringArray.Dispose();
                mValueArray.Dispose();
            }

            public MValue Peek()
            {
                return mValueArrayBuffer.Peek();
            }

            public ulong GetSize()
            {
                return size;
            }

            public MValue.Type GetPreviousType()
            {
                return mValueArrayBuffer.GetPreviousType();
            }
            
            public bool HasNext()
            {
                return mValueArrayBuffer.HasNext();
            }
            
            public void SkipValue()
            {
                mValueArrayBuffer.SkipValue();
            }
        }

        private class MValueStartReader : IReadableMValue
        {
            private MValueArrayBuffer mValueArrayBuffer;

            private MValue mValue;

            public MValueStartReader(ref MValue mValue)
            {
                this.mValue = mValue;
                mValueArrayBuffer = new MValueArrayBuffer();
            }

            public MValue GetNext()
            {
                return mValue;
            }

            public bool GetNext(out bool value)
            {
                if (mValue.type != MValue.Type.BOOL)
                {
                    value = default;
                    return false;
                }

                value = mValue.GetBool();
                return true;
            }

            public bool GetNext(out int value)
            {
                if (mValue.type != MValue.Type.INT)
                {
                    value = default;
                    return false;
                }

                value = (int) mValue.GetInt();
                return true;
            }

            public bool GetNext(out uint value)
            {
                if (mValue.type != MValue.Type.UINT)
                {
                    value = default;
                    return false;
                }

                value = (uint) mValue.GetUint();
                return true;
            }

            public bool GetNext(out long value)
            {
                if (mValue.type != MValue.Type.INT)
                {
                    value = default;
                    return false;
                }

                value = mValue.GetInt();
                return true;
            }

            public bool GetNext(out ulong value)
            {
                if (mValue.type != MValue.Type.UINT)
                {
                    value = default;
                    return false;
                }

                value = mValue.GetUint();
                return true;
            }

            public bool GetNext(out float value)
            {
                if (mValue.type != MValue.Type.DOUBLE)
                {
                    value = default;
                    return false;
                }

                value = (float) mValue.GetDouble();
                return true;
            }

            public bool GetNext(out double value)
            {
                if (mValue.type != MValue.Type.DOUBLE)
                {
                    value = default;
                    return false;
                }

                value = mValue.GetDouble();
                return true;
            }

            public bool GetNext(out string value)
            {
                if (mValue.type != MValue.Type.STRING)
                {
                    value = default;
                    return false;
                }

                value = mValue.GetString();
                return true;
            }

            public void Dispose()
            {
            }

            public MValue Peek()
            {
                return mValue;
            }

            public ulong GetSize()
            {
                return 1;
            }
            
            public MValue.Type GetPreviousType()
            {
                return mValueArrayBuffer.GetPreviousType();
            }
            
            public bool HasNext()
            {
                return mValueArrayBuffer.HasNext();
            }
            
            public void SkipValue()
            {
                mValueArrayBuffer.SkipValue();
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
            //CheckObject();
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
            insideObject = currents.TryPeek(out readableMValue);
        }

        public void BeginArray()
        {
            //CheckArray();
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
            CheckArray();
            currents.Pop().Dispose(); // Pop mValueObject we already have
            insideObject = currents.TryPeek(out readableMValue);
        }

        private void CheckObject()
        {
            if (!insideObject && readableMValue.Peek().type != MValue.Type.DICT)
            {
                throw new InvalidDataException("Not inside a object or array");
            }
        }

        private void CheckArray()
        {
            if (!insideObject && readableMValue.Peek().type != MValue.Type.LIST)
            {
                throw new InvalidDataException("Not inside a object or array");
            }
        }

        private void CheckObjectOrArray()
        {
            var mValue = readableMValue.Peek();
            if (!insideObject && mValue.type != MValue.Type.DICT && mValue.type != MValue.Type.LIST)
            {
                throw new InvalidDataException("Not inside a object or array");
            }
        }

        private void CheckName()
        {
            // Check if we have more values then names
            if (readableMValue.GetSize() > ((MValueObjectReader) readableMValue).GetSize())
            {
                throw new InvalidDataException("Expect a NextValue call, but tried to read a name instead");
            }
        }

        private void CheckValue()
        {
            if (!(readableMValue is MValueObjectReader mValueObjectReader)) return;
            // Check if we have more names then values
            if (readableMValue.GetSize() < mValueObjectReader.GetSize())
            {
                throw new InvalidDataException("Expect a NextName() call, but tried to read a value instead");
            }
        }

        public bool HasNext()
        {
            CheckObjectOrArray();
            switch (readableMValue)
            {
                case MValueObjectReader mValueObjectReader:
                    return mValueObjectReader.GetSize() > 0 &&
                           mValueObjectReader.HasNext();
                default:
                    return readableMValue.HasNext();
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
            CheckObjectOrArray();
            CheckValue();
            if (!readableMValue.GetNext(out bool value))
            {
                throw new InvalidDataException(
                    $"Expected a bool but found a {readableMValue.GetPreviousType()}");
            }

            return value;
        }

        public int NextInt()
        {
            CheckObjectOrArray();
            CheckValue();
            if (!readableMValue.GetNext(out int value))
            {
                throw new InvalidDataException(
                    $"Expected a int but found a {readableMValue.GetPreviousType()}");
            }

            return value;
        }

        public long NextLong()
        {
            CheckObjectOrArray();
            CheckValue();
            if (!readableMValue.GetNext(out long value))
            {
                throw new InvalidDataException(
                    $"Expected a long but found a {readableMValue.GetPreviousType()}");
            }

            return value;
        }

        public uint NextUInt()
        {
            CheckObjectOrArray();
            CheckValue();
            if (!readableMValue.GetNext(out uint value))
            {
                throw new InvalidDataException(
                    $"Expected a uint but found a {readableMValue.GetPreviousType()}");
            }

            return value;
        }

        public ulong NextULong()
        {
            CheckObjectOrArray();
            CheckValue();
            if (!readableMValue.GetNext(out ulong value))
            {
                throw new InvalidDataException(
                    $"Expected a ulong but found a {readableMValue.GetPreviousType()}");
            }

            return value;
        }

        public double NextDouble()
        {
            CheckObjectOrArray();
            CheckValue();
            if (!readableMValue.GetNext(out double value))
            {
                throw new InvalidDataException(
                    $"Expected a double but found a {readableMValue.GetPreviousType()}");
            }

            return value;
        }

        public string NextString()
        {
            CheckObjectOrArray();
            CheckValue();
            if (!readableMValue.GetNext(out string value))
            {
                throw new InvalidDataException(
                    $"Expected a string but found a {readableMValue.GetPreviousType()}");
            }

            return value;
        }

        public void SkipValue()
        {
            CheckObjectOrArray();
            CheckValue();
            readableMValue.SkipValue();
        }

        public MValueReaderToken Peek()
        {
            if (readableMValue.Peek().type == MValue.Type.DICT) return MValueReaderToken.Object;
            if (readableMValue.Peek().type == MValue.Type.LIST) return MValueReaderToken.Array;
            if (readableMValue is MValueObjectReader mValueObjectReader &&
                readableMValue.GetSize() >= mValueObjectReader.GetSize())
                return MValueReaderToken.Value;
            return readableMValue.GetSize() <= ((MValueObjectReader) readableMValue).GetSize()
                ? MValueReaderToken.Name
                : MValueReaderToken.Unknown;
        }
    }
}