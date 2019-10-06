using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Args
{
    internal class MValueWriter : IMValueWriter
    {
        public interface IWritableMValue
        {
            List<MValue> Values { get; }

            byte Type { get; }

            void Append(IWritableMValue writable);

            MValue ToMValue();
        }

        public struct MValueObject : IWritableMValue
        {
            public byte Type => 0;
            public readonly List<string> Names;
            public List<MValue> Values { get; }

            public MValueObject(List<string> names, List<MValue> values)
            {
                Names = names;
                Values = values;
            }

            public void Append(IWritableMValue writable)
            {
                // Only valid when we have a open Name without a value
                if (Names.Count > Values.Count)
                {
                    Values.Add(writable.ToMValue());
                }
            }

            public MValue ToMValue()
            {
                return MValue.Create(Values.ToArray(), Names.ToArray());
            }
        }

        public struct MValueArray : IWritableMValue
        {
            public byte Type => 1;
            public List<MValue> Values { get; }

            public MValueArray(List<MValue> values)
            {
                Values = values;
            }

            public void Append(IWritableMValue writable)
            {
                Values.Add(writable.ToMValue());
            }

            public MValue ToMValue()
            {
                return MValue.Create(Values.ToArray());
            }
        }

        // This is the current stack
        private readonly Stack<IWritableMValue> currents = new Stack<IWritableMValue>();

        private IWritableMValue
            root; // This can be a MValueObject or MValueArray, this is the first object / array created

        // Temp values for faster peeks

        private IWritableMValue curr;

        private IWritableMValue currCurr;

        public void BeginObject()
        {
            var currentObj = new MValueObject(new List<string>(), new List<MValue>());

            currents.Push(currentObj);
        }

        public void EndObject()
        {
            if (currents.TryPop(out currCurr))
            {
                if (currCurr.Type != 0)
                {
                    throw new ArithmeticException("Expected EndArray, got EndObject");
                }

                if (currents.TryPeek(out curr))
                {
                    curr.Append(currCurr);
                }
                else
                {
                    // We are first current
                    root = currCurr;
                }
            }
            else
            {
                throw new ArithmeticException("Invalid EndObject without BeginObject");
            }
        }

        public void BeginArray()
        {
            var currentArr = new MValueArray(new List<MValue>());

            currents.Push(currentArr);
        }

        public void EndArray()
        {
            if (currents.TryPop(out currCurr))
            {
                if (currCurr.Type != 1)
                {
                    throw new ArithmeticException("Expected EndObject, got EndArray");
                }

                if (currents.TryPeek(out curr))
                {
                    curr.Append(currCurr);
                }
                else
                {
                    // We are first current
                    root = currCurr;
                }
            }
            else
            {
                throw new ArithmeticException("Invalid EndArray without BeginArray");
            }
        }

        public void Name(string name)
        {
            if (currents.TryPeek(out currCurr))
            {
                ((MValueObject) currCurr).Names.Add(name);
            }
        }

        public void Value(bool value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(MValue.Create(value));
            }
        }

        public void Value(int value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(MValue.Create(value));
            }
        }

        public void Value(long value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(MValue.Create(value));
            }
        }

        public void Value(uint value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(MValue.Create(value));
            }
        }

        public void Value(ulong value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(MValue.Create(value));
            }
        }

        public void Value(double value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(MValue.Create(value));
            }
        }

        public void Value(string value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(MValue.Create(value));
            }
        }

        public void Value(ICheckpoint value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(MValue.Create(value));
            }
        }

        public void Value(IBlip value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(MValue.Create(value));
            }
        }

        public void Value(IVehicle value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(MValue.Create(value));
            }
        }

        public void Value(IPlayer value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(MValue.Create(value));
            }
        }

        //TODO: function support

        public MValue ToMValue() => root?.ToMValue() ?? MValue.Nil;
    }
}