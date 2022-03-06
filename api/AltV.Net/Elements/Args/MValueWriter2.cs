using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Args
{
    public class MValueWriter2 : IMValueWriter
    {
        public interface IWritableMValue
        {
            List<object> Values { get; }

            byte Type { get; }

            void Append(IWritableMValue writable);

            void ToMValue(out MValueConst mValue);
        }

        public struct MValueObject : IWritableMValue
        {
            public byte Type => 0;
            public readonly List<string> Names;
            public List<object> Values { get; }

            public MValueObject(List<string> names, List<object> values)
            {
                Names = names;
                Values = values;
            }

            public void Append(IWritableMValue writable)
            {
                // Only valid when we have a open Name without a value
                if (Names.Count > Values.Count)
                {
                    writable.ToMValue(out var mValue);
                    Values.Add(mValue);
                }
                else
                {
                    throw new ArithmeticException("Name(name) is required before writing a object.");
                }
            }

            public void ToMValue(out MValueConst mValue)
            {
                var size = (ulong) Values.Count;
                var mValues = new MValueConst[size];
                Alt.Core.CreateMValues(mValues, Values.ToArray());
                var keys = Names.ToArray();

                Alt.Core.CreateMValueDict(out mValue, keys, mValues, size);
                for (ulong i = 0; i < size; i++)
                {
                    mValues[i].Dispose();
                }
            }
        }

        public struct MValueArray : IWritableMValue
        {
            public byte Type => 1;
            public List<object> Values { get; }

            public MValueArray(List<object> values)
            {
                Values = values;
            }

            public void Append(IWritableMValue writable)
            {
                writable.ToMValue(out var mValue);
                Values.Add(mValue);
            }

            public void ToMValue(out MValueConst mValue)
            {
                var size = (ulong) Values.Count;
                var mValues = new MValueConst[size];
                Alt.Core.CreateMValues(mValues, Values.ToArray());
                Alt.Core.CreateMValueList(out mValue, mValues, size);
                for (ulong i = 0; i < size; i++)
                {
                    mValues[i].Dispose();
                }
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
            var currentObj = new MValueObject(new List<string>(), new List<object>());

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
            var currentArr = new MValueArray(new List<object>());

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
                currCurr.Values.Add(value);
            }
        }

        public void Value(int value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(long value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(uint value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(ulong value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(float value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(double value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(string value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(ICheckpoint value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(IBlip value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(IVehicle value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(IPlayer value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(ICollection value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(IWritable value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(Position value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(Rotation value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(Rgba value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(Vector3 value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        public void Value(Vector2 value)
        {
            if (currents.TryPeek(out currCurr))
            {
                currCurr.Values.Add(value);
            }
        }

        //TODO: function support

        public bool ToMValue(out MValueConst mValue)
        {
            if (root != null)
            {
                root.ToMValue(out mValue);
                return true;
            }
            else
            {
                mValue = MValueConst.Nil;       
            }

            return false;
        }
    }
}