using System.Collections.Generic;
using System.Linq;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net
{
    public class MValueWriter
    {
        public interface IWritableMValue
        {
            List<MValue> Values { get; }
            
            void Append(IWritableMValue writable);

            MValue ToMValue();
        }

        public struct MValueObject : IWritableMValue
        {
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
                    Values.Append(writable.ToMValue());
                }
            }

            public MValue ToMValue()
            {
                return MValue.Create(Values.ToArray(), Names.ToArray());
            }
        }

        public struct MValueArray : IWritableMValue
        {
            public List<MValue> Values { get; }

            public MValueArray(List<MValue> values)
            {
                Values = values;
            }

            public void Append(IWritableMValue writable)
            {
                Values.Append(writable.ToMValue());
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

        public MValueWriter()
        {
        }

        public void BeginObject()
        {
            var currentObj = new MValueObject(new List<string>(), new List<MValue>());

            currents.Push(currentObj);
        }

        public void EndObject()
        {
            if (currents.TryPop(out currCurr))
            {
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