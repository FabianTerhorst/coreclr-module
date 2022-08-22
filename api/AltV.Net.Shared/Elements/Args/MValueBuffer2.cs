using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Args
{
    public struct MValueBuffer2
    {
        private readonly ISharedCore core;
        private readonly IMValueConst[] values;

        private int position;

        public int size;

        public MValueBuffer2(ISharedCore core, IMValueConst[] values)
        {
            this.core = core;
            this.values = values;
            this.position = 0;
            this.size = values.Length;
        }

        /// <summary>
        /// Consumes and returns next MValue in the array
        /// </summary>
        /// <returns></returns>
        public void GetNext(out IMValueConst mValue)
        {
            if (size == 0)
            {
                mValue = MValueConst.Nil;
                return;
            }

            size--;
            mValue = values[position++];
        }

        public void Peek(out IMValueConst mValue)
        {
            if (size == 0)
            {
                mValue = MValueConst.Nil;
                return;
            }

            mValue = values[position];
        }

        public bool GetNext(out bool value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != MValueType.Bool)
            {
                value = default;
                return false;
            }

            value = mValue.GetBool();
            return true;
        }

        public bool GetNext(out int value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != MValueType.Int)
            {
                value = default;
                return false;
            }

            value = (int) mValue.GetInt();
            return true;
        }

        public bool GetNext(out uint value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != MValueType.Uint)
            {
                value = default;
                return false;
            }

            value = (uint) mValue.GetUint();
            return true;
        }

        public bool GetNext(out long value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != MValueType.Int)
            {
                value = default;
                return false;
            }

            value = mValue.GetInt();
            return true;
        }

        public bool GetNext(out ulong value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != MValueType.Uint)
            {
                value = default;
                return false;
            }

            value = mValue.GetUint();
            return true;
        }

        public bool GetNext(out float value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != MValueType.Double)
            {
                value = default;
                return false;
            }

            value = (float) mValue.GetDouble();
            return true;
        }

        public bool GetNext(out double value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            switch (mValue.type)
            {
                case MValueType.Double:
                    value = mValue.GetDouble();
                    return true;
                case MValueType.Int:
                    value = mValue.GetInt();
                    return true;
                case MValueType.Uint:
                    value = mValue.GetUint();
                    return true;
                default:
                    value = default;
                    return false;
            }
        }

        public bool GetNext(out string value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != MValueType.String)
            {
                value = default;
                return false;
            }

            value = mValue.GetString();
            return true;
        }

        public bool GetNext(out Position value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != MValueType.Vector3)
            {
                value = default;
                return false;
            }

            value = mValue.GetVector3();
            return true;
        }

        public bool GetNext(out Rgba value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != MValueType.Rgba)
            {
                value = default;
                return false;
            }

            value = mValue.GetRgba();
            return true;
        }

        public bool GetNext(out byte[] value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != MValueType.ByteArray)
            {
                value = default;
                return false;
            }

            value = mValue.GetByteArray();
            return true;
        }

        /*public bool GetNextConvertible<T>(out object obj)
        {
            if (size == 0)
            {
                obj = null;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type == IMValueConst.Type.LIST || mValue.type == IMValueConst.Type.DICT)
            {
                MValueAdapters.FromMValue(ref mValue, typeof(T), out obj);
                return true;
            }


            obj = null;
            return false;
        }*/

        /*public bool GetNext(out MValue.Function value)
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != IMValueConst.Type.FUNCTION)
            {
                value = default;
                return false;
            }

            value = mValue.GetFunction();
            return true;
        }*/

        public bool GetNext(out IMValueConst[] valuesList)
        {
            unsafe
            {
                if (size == 0)
                {
                    valuesList = default;
                    return false;
                }

                var mValue = values[position++];
                size--;
                if (mValue.type != MValueType.List)
                {
                    valuesList = default;
                    return false;
                }

                valuesList = mValue.GetList();
                return true;
            }
        }

        public void SkipValue()
        {
            if (size == 0)
            {
                return;
            }

            position++;
            size--;
        }

        public bool GetNext<TEntity>(out TEntity value) where TEntity : ISharedBaseObject
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != MValueType.BaseObject)
            {
                value = default;
                return false;
            }

            var entity = mValue.GetBaseObject(); 
            if (entity != null)
            {
                if (entity is TEntity typedEntity)
                {
                    value = typedEntity;
                    return true;
                }

                value = default;
                return false;
            }

            value = default;
            return false;
        }

        public bool HasNext()
        {
            return size > 0;
        }

        public MValueType GetPreviousType()
        {
            var mValue = values[position - 1];
            return mValue.type;
        }
    }
}