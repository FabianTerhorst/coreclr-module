using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Args
{
    public struct MValueBuffer2
    {
        private readonly MValueConst[] values;

        private int position;

        public int size;

        public MValueBuffer2(MValueConst[] values)
        {
            this.values = values;
            this.position = 0;
            this.size = values.Length;
        }

        /// <summary>
        /// Consumes and returns next MValue in the array
        /// </summary>
        /// <returns></returns>
        public void GetNext(out MValueConst mValue)
        {
            if (size == 0)
            {
                mValue = MValueConst.Nil;
                return;
            }

            size--;
            mValue = values[position++];
        }

        public void Peek(out MValueConst mValue)
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
            if (mValue.type != MValueConst.Type.Bool)
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
            if (mValue.type != MValueConst.Type.Int)
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
            if (mValue.type != MValueConst.Type.Uint)
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
            if (mValue.type != MValueConst.Type.Int)
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
            if (mValue.type != MValueConst.Type.Uint)
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
            if (mValue.type != MValueConst.Type.Double)
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
                case MValueConst.Type.Double:
                    value = mValue.GetDouble();
                    return true;
                case MValueConst.Type.Int:
                    value = mValue.GetInt();
                    return true;
                case MValueConst.Type.Uint:
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
            if (mValue.type != MValueConst.Type.String)
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
            if (mValue.type != MValueConst.Type.Vector3)
            {
                value = default;
                return false;
            }

            value = Position.Zero;
            mValue.GetVector3(ref value);
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
            if (mValue.type != MValueConst.Type.Rgba)
            {
                value = default;
                return false;
            }

            value = Rgba.Zero;
            mValue.GetRgba(ref value);
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
            if (mValue.type != MValueConst.Type.ByteArray)
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
            if (mValue.type == MValueConst.Type.LIST || mValue.type == MValueConst.Type.DICT)
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
            if (mValue.type != MValueConst.Type.FUNCTION)
            {
                value = default;
                return false;
            }

            value = mValue.GetFunction();
            return true;
        }*/

        public bool GetNext(out MValueConst[] valuesList)
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
                if (mValue.type != MValueConst.Type.List)
                {
                    valuesList = default;
                    return false;
                }


                var listSize = Alt.Core.Library.Shared.MValueConst_GetListSize(mValue.nativePointer);
                var valueArrayRef = new IntPtr[listSize];
                valuesList = new MValueConst[listSize];
                Alt.Core.Library.Shared.MValueConst_GetList(mValue.nativePointer, valueArrayRef);
                for (ulong i = 0; i < listSize; i++)
                {
                    valuesList[i] = new MValueConst(valueArrayRef[i]);
                }

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

        public bool GetNext<TEntity>(out TEntity value) where TEntity : IEntity
        {
            if (size == 0)
            {
                value = default;
                return false;
            }

            var mValue = values[position++];
            size--;
            if (mValue.type != MValueConst.Type.BaseObject)
            {
                value = default;
                return false;
            }

            var entityType = BaseObjectType.Undefined;
            var ptr = mValue.GetEntityPointer(ref entityType);
            if (Alt.Module.BaseBaseObjectPool.Get(ptr, entityType, out var entity))
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

        public MValueConst.Type GetPreviousType()
        {
            var mValue = values[position - 1];
            return mValue.type;
        }
    }
}