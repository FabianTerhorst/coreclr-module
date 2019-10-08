using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AltV.Net.Elements.Args
{
    //TODO: needs more testing
    internal class MValueObjectReader : IMValueReader
    {
        private interface IReadableMValue
        {
            object GetNext();

            int GetValueSize();

            void SkipValue();

            object Peek();
        }

        private struct MValueArrayReader : IReadableMValue
        {
            private readonly object[] values;

            private int index;

            public MValueArrayReader(ICollection collection)
            {
                values = new object[collection.Count];
                index = 0;
                collection.CopyTo(values, 0);
            }

            public object GetNext()
            {
                return values[index++];
            }

            public int GetValueSize()
            {
                return values.Length - index;
            }

            public void SkipValue()
            {
                index++;
            }

            public object Peek()
            {
                return values[index];
            }
        }

        private struct MValueDictionaryReader : IReadableMValue
        {
            private readonly object[] values;

            private readonly string[] names;

            private int index;

            private int nameIndex;

            public MValueDictionaryReader(IDictionary dictionary)
            {
                values = new object[dictionary.Count];
                names = new string[dictionary.Count];
                dictionary.Values.CopyTo(values, 0);
                dictionary.Keys.CopyTo(names, 0);
                index = 0;
                nameIndex = 0;
            }

            public object GetNext()
            {
                return values[index++];
            }

            public string GetNextName()
            {
                return names[nameIndex++];
            }

            public void SkipValue()
            {
                index++;
            }

            public void SkipName()
            {
                nameIndex++;
            }

            public int GetValueSize()
            {
                return values.Length - index;
            }

            public int GetNameSize()
            {
                return names.Length - nameIndex;
            }
            
            public object Peek()
            {
                return values[index];
            }
        }

        private struct MValueStartReader : IReadableMValue
        {
            private object obj;

            private int size;

            public MValueStartReader(object obj)
            {
                this.obj = obj;
                size = 1;
            }

            public object GetNext()
            {
                return obj;
            }

            public int GetValueSize()
            {
                return size;
            }

            public void SkipValue()
            {
                obj = null;
                size = 0;
            }
            
            public object Peek()
            {
                return obj;
            }
        }

        private bool insideObject = false;

        private readonly Stack<IReadableMValue> currents = new Stack<IReadableMValue>();

        // Temp values for faster access

        private IReadableMValue readableMValue;

        public MValueObjectReader(object obj)
        {
            readableMValue = new MValueStartReader(obj);
        }

        public void BeginObject()
        {
            //CheckObjectOrArray();
            var obj = readableMValue.GetNext();

            if (!(obj is IDictionary dictionary))
            {
                return;
            }

            readableMValue = new MValueDictionaryReader(dictionary);
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
            //CheckObjectOrArray();
            var obj = readableMValue.GetNext();

            if (!(obj is ICollection collection))
            {
                return;
            }

            readableMValue = new MValueArrayReader(collection);
            currents.Push(readableMValue);
            insideObject = true;
        }

        public void EndArray()
        {
            CheckArray();
            currents.Pop(); // Pop mValueObject we already have
            insideObject = currents.TryPop(out readableMValue);
        }

        private void CheckObject()
        {
            if (!insideObject && readableMValue.Peek().GetType() != typeof(IDictionary))
            {
                throw new InvalidDataException("Not inside a object or array");
            }
        }
        
        private void CheckArray()
        {
            if (!insideObject && readableMValue.Peek().GetType() != typeof(object[]))
            {
                throw new InvalidDataException("Not inside a object or array");
            }
        }

        private void CheckObjectOrArray()
        {
            if (!insideObject && readableMValue.Peek().GetType() != typeof(IDictionary) && (readableMValue.Peek().GetType() != typeof(object[])))
            {
                throw new InvalidDataException("Not inside a object or array");
            }
        }

        private void CheckName()
        {
            // Check if we have more values then names
            if (((MValueDictionaryReader) readableMValue).GetValueSize() >
                ((MValueDictionaryReader) readableMValue).GetNameSize())
            {
                throw new InvalidDataException("Expect a NextValue call, but tried to read a name instead");
            }
        }

        private void CheckValue()
        {
            if (!(readableMValue is MValueDictionaryReader mValueObjectReader)) return;
            // Check if we have more names then values
            if (mValueObjectReader.GetValueSize() < mValueObjectReader.GetNameSize())
            {
                throw new InvalidDataException("Expect a NextName() call, but tried to read a value instead");
            }
        }

        public bool HasNext()
        {
            CheckObjectOrArray();
            switch (readableMValue)
            {
                case MValueDictionaryReader mValueDictionaryReader:
                    return mValueDictionaryReader.GetNameSize() > 0 &&
                           mValueDictionaryReader.GetValueSize() > 0;
                default:
                    return readableMValue.GetValueSize() > 0;
            }
        }

        public string NextName()
        {
            CheckObject();
            if (!(readableMValue is MValueDictionaryReader))
            {
                throw new InvalidDataException("Not inside a object");
            }

            CheckName();

            return ((MValueDictionaryReader) readableMValue).GetNextName();
        }

        public void SkipName()
        {
            CheckObject();
            if (!(readableMValue is MValueDictionaryReader))
            {
                throw new InvalidDataException("Not inside a object");
            }

            CheckName();

            ((MValueDictionaryReader) readableMValue).SkipName();
        }

        public bool NextBool()
        {
            CheckObjectOrArray();
            CheckValue();
            var next = readableMValue.GetNext();
            if (!(next is bool value))
            {
                throw new InvalidDataException(
                    $"Expected a bool but found a {next.GetType()}");
            }

            return value;
        }

        public int NextInt()
        {
            CheckObjectOrArray();
            CheckValue();
            var next = readableMValue.GetNext();
            if (!(next is int value))
            {
                throw new InvalidDataException(
                    $"Expected a int but found a {next.GetType()}");
            }

            return value;
        }

        public long NextLong()
        {
            CheckObjectOrArray();
            CheckValue();
            var next = readableMValue.GetNext();
            if (!(next is long value))
            {
                throw new InvalidDataException(
                    $"Expected a long but found a {next.GetType()}");
            }

            return value;
        }

        public uint NextUInt()
        {
            CheckObjectOrArray();
            CheckValue();
            var next = readableMValue.GetNext();
            if (!(next is uint value))
            {
                throw new InvalidDataException(
                    $"Expected a uint but found a {next.GetType()}");
            }

            return value;
        }

        public ulong NextULong()
        {
            CheckObjectOrArray();
            CheckValue();
            var next = readableMValue.GetNext();
            if (!(next is ulong value))
            {
                throw new InvalidDataException(
                    $"Expected a ulong but found a {next.GetType()}");
            }

            return value;
        }

        public double NextDouble()
        {
            CheckObjectOrArray();
            CheckValue();
            var next = readableMValue.GetNext();
            if (!(next is double value))
            {
                throw new InvalidDataException(
                    $"Expected a double but found a {next.GetType()}");
            }

            return value;
        }

        public string NextString()
        {
            CheckObjectOrArray();
            CheckValue();
            var next = readableMValue.GetNext();
            if (!(next is string value))
            {
                throw new InvalidDataException(
                    $"Expected a string but found a {next.GetType()}");
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
            if (insideObject) return MValueReaderToken.Object;
            if (readableMValue is MValueDictionaryReader mValueObjectReader &&
                mValueObjectReader.GetValueSize() >= mValueObjectReader.GetNameSize())
            {
                return MValueReaderToken.Value;
            }

            return ((MValueDictionaryReader) readableMValue).GetValueSize() <=
                   ((MValueDictionaryReader) readableMValue).GetNameSize()
                ? MValueReaderToken.Name
                : MValueReaderToken.Unknown;
        }
    }
}