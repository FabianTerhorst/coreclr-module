using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using AltV.Net.Native;

namespace AltV.Net.Elements.Args
{
    internal class MValueReader2 : IMValueReader
    {
        private interface IReadableMValue
        {
            void GetNext(out MValueConst mValue);

            void Dispose();

            void Peek(out MValueConst mValue);

            ulong GetSize();

            bool GetNext(out bool value);

            bool GetNext(out int value);

            bool GetNext(out uint value);

            bool GetNext(out long value);

            bool GetNext(out ulong value);

            bool GetNext(out float value);

            bool GetNext(out double value);

            bool GetNext(out string value);

            MValueConst.Type GetPreviousType();

            bool HasNext();

            void SkipValue();
        }

        private class MValueArrayReader : IReadableMValue
        {
            private MValueConst[] mValueArray;

            private MValueBuffer2 mValueArrayBuffer;

            public MValueArrayReader(MValueConst[] mValueArray)
            {
                this.mValueArray = mValueArray;
                mValueArrayBuffer = new MValueBuffer2(mValueArray);
            }

            public void GetNext(out MValueConst mValue)
            {
                mValueArrayBuffer.GetNext(out mValue);
            }

            public bool GetNext(out bool value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out int value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out uint value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out long value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out ulong value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out float value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out double value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out string value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public void Dispose()
            {
                for (int i = 0, length = mValueArray.Length; i < length; i++)
                {
                    mValueArray[i].Dispose();
                }
            }

            public void Peek(out MValueConst mValue)
            {
                mValueArrayBuffer.Peek(out mValue);
            }

            public ulong GetSize()
            {
                return (ulong) mValueArrayBuffer.size;
            }

            public MValueConst.Type GetPreviousType()
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
            private string[] stringArray;
            private MValueConst[] mValueArray;
            private MValueBuffer2 mValueArrayBuffer;
            private int nameOffset;

            public MValueObjectReader(string[] stringArray, MValueConst[] mValueArray)
            {
                this.stringArray = stringArray;
                this.mValueArray = mValueArray;
                mValueArrayBuffer = new MValueBuffer2(mValueArray);
                nameOffset = 0;
            }

            public void GetNext(out MValueConst mValue)
            {
                mValueArrayBuffer.GetNext(out mValue);
            }

            public bool GetNext(out bool value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out int value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out uint value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out long value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out ulong value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out float value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out double value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public bool GetNext(out string value)
            {
                var result = mValueArrayBuffer.GetNext(out value);
                return result;
            }

            public string GetNextName()
            {
                var value = stringArray[nameOffset++];
                return value;
            }

            public void SkipNextName()
            {
                nameOffset++;
            }

            public void Dispose()
            {
                for (int i = 0, length = mValueArray.Length; i < length; i++)
                {
                    mValueArray[i].Dispose();
                }
            }

            public void Peek(out MValueConst mValueConst)
            {
                mValueArrayBuffer.Peek(out mValueConst);
            }

            public ulong GetSize()
            {
                return (ulong) mValueArrayBuffer.size;
            }

            public MValueConst.Type GetPreviousType()
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
            private MValueConst mValue;

            public MValueStartReader(in MValueConst mValue)
            {
                this.mValue = mValue;
            }

            public void GetNext(out MValueConst mValue)
            {
                mValue = this.mValue;
            }

            public bool GetNext(out bool value)
            {
                if (mValue.type != MValueConst.Type.BOOL)
                {
                    value = default;
                    return false;
                }

                value = mValue.GetBool();
                return true;
            }

            public bool GetNext(out int value)
            {
                if (mValue.type != MValueConst.Type.INT)
                {
                    value = default;
                    return false;
                }

                value = (int) mValue.GetInt();
                return true;
            }

            public bool GetNext(out uint value)
            {
                if (mValue.type != MValueConst.Type.UINT)
                {
                    value = default;
                    return false;
                }

                value = (uint) mValue.GetUint();
                return true;
            }

            public bool GetNext(out long value)
            {
                if (mValue.type != MValueConst.Type.INT)
                {
                    value = default;
                    return false;
                }

                value = mValue.GetInt();
                return true;
            }

            public bool GetNext(out ulong value)
            {
                if (mValue.type != MValueConst.Type.UINT)
                {
                    value = default;
                    return false;
                }

                value = mValue.GetUint();
                return true;
            }

            public bool GetNext(out float value)
            {
                if (mValue.type != MValueConst.Type.DOUBLE)
                {
                    value = default;
                    return false;
                }

                value = (float) mValue.GetDouble();
                return true;
            }

            public bool GetNext(out double value)
            {
                if (mValue.type != MValueConst.Type.DOUBLE)
                {
                    value = default;
                    return false;
                }

                value = mValue.GetDouble();
                return true;
            }

            public bool GetNext(out string value)
            {
                if (mValue.type != MValueConst.Type.STRING)
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

            public void Peek(out MValueConst mValue)
            {
                mValue = this.mValue;
            }

            public ulong GetSize()
            {
                return 1;
            }

            public MValueConst.Type GetPreviousType()
            {
                return MValueConst.Type.NIL;
            }

            public bool HasNext()
            {
                return true;
            }

            public void SkipValue()
            {
            }
        }

        private bool insideObject;

        private readonly Stack<IReadableMValue> currents = new Stack<IReadableMValue>();

        // Temp values for faster access

        private IReadableMValue readableMValue;

        public MValueReader2(in MValueConst mValue)
        {
            readableMValue = new MValueStartReader(in mValue);
        }

        public void BeginObject()
        {
            //CheckObject();
            readableMValue.GetNext(out MValueConst mValue);

            if (mValue.type != MValueConst.Type.DICT)
            {
                throw new InvalidDataException("Expected object but got " + mValue.type);
            }

            var size = AltNative.MValueNative.MValueConst_GetDictSize(mValue.nativePointer);
            var stringArrayPtr = new IntPtr[size];
            var valueArrayPtr = new IntPtr[size];
            AltNative.MValueNative.MValueConst_GetDict(mValue.nativePointer, stringArrayPtr, valueArrayPtr);
            var keyArray = new string[size];
            var valueArray = new MValueConst[size];
            for (ulong i = 0; i < size; i++)
            {
                var keyPointer = stringArrayPtr[i];
                keyArray[i] = Marshal.PtrToStringUTF8(keyPointer);
                AltNative.FreeCharArray(keyPointer);
                valueArray[i] = new MValueConst(valueArrayPtr[i]);
            }

            readableMValue = new MValueObjectReader(keyArray, valueArray);
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
            readableMValue.GetNext(out MValueConst mValue);

            if (mValue.type != MValueConst.Type.LIST)
            {
                throw new InvalidDataException("Expected array but got " + mValue.type);
            }

            var size = AltNative.MValueNative.MValueConst_GetListSize(mValue.nativePointer);
            var valueArrayRef = new IntPtr[size];
            AltNative.MValueNative.MValueConst_GetList(mValue.nativePointer, valueArrayRef);
            readableMValue = new MValueArrayReader(MValueConst.CreateFrom(valueArrayRef));
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
            if (!insideObject)
            {
                readableMValue.Peek(out var mValue);
                if (mValue.type != MValueConst.Type.DICT)
                {
                    throw new InvalidDataException("Not inside a object or array");
                }
            }
        }

        private void CheckArray()
        {
            if (!insideObject)
            {
                readableMValue.Peek(out var mValue);
                if (mValue.type != MValueConst.Type.LIST)
                {
                    throw new InvalidDataException("Not inside a object or array");
                }
            }
        }

        private void CheckObjectOrArray()
        {
            readableMValue.Peek(out var mValue);
            if (!insideObject && mValue.type != MValueConst.Type.DICT && mValue.type != MValueConst.Type.LIST)
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
            readableMValue.Peek(out var mValue);
            if (mValue.type == MValueConst.Type.DICT) return MValueReaderToken.Object;
            if (mValue.type == MValueConst.Type.LIST) return MValueReaderToken.Array;
            if (mValue.type == MValueConst.Type.NIL) return MValueReaderToken.Nil;
            if (readableMValue is MValueObjectReader mValueObjectReader &&
                readableMValue.GetSize() >= mValueObjectReader.GetSize())
                return MValueReaderToken.Value;
            return readableMValue.GetSize() <= ((MValueObjectReader) readableMValue).GetSize()
                ? MValueReaderToken.Name
                : MValueReaderToken.Unknown;
        }

        public void Dispose()
        {
            IReadableMValue popped;
            while (currents.TryPop(out popped))
            {
                popped.Dispose();
            }
        }
    }
}