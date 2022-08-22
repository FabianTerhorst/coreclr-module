using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static void SetMetaData(string key, object value) => Core.SetMetaData(key, value);
        
        public static bool HasMetaData(string key) => Core.HasMetaData(key);

        public static void DeleteMetaData(string key) => Core.DeleteMetaData(key);
        
        public static bool GetMetaData(string key, out int result)
        {
            Core.GetMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueType.Int)
                {
                    result = default;
                    return false;
                }

                result = (int) mValue.GetInt();
            }

            return true;
        }

        public static bool GetMetaData(string key, out uint result)
        {
            Core.GetMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueType.Uint)
                {
                    result = default;
                    return false;
                }

                result = (uint) mValue.GetUint();
            }

            return true;
        }

        public static bool GetMetaData(string key, out float result)
        {
            Core.GetMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueType.Double)
                {
                    result = default;
                    return false;
                }

                result = (float) mValue.GetDouble();
            }

            return true;
        }

        public static bool GetMetaData<T>(string key, out T result)
        {
            Core.GetMetaData(key, out var mValue);
            using (mValue)
            {
                if (!(mValue.ToObject() is T cast))
                {
                    result = default;
                    return false;
                }

                result = cast;
            }

            return true;
        }
        
        public static void SetSyncedMetaData(string key, object value) => Core.SetSyncedMetaData(key, value);
        
        public static bool HasSyncedMetaData(string key) => Core.HasSyncedMetaData(key);

        public static void DeleteSyncedMetaData(string key) => Core.DeleteSyncedMetaData(key);
        
        public static bool GetSyncedMetaData(string key, out int result)
        {
            Core.GetSyncedMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueType.Int)
                {
                    result = default;
                    return false;
                }

                result = (int) mValue.GetInt();
            }

            return true;
        }

        public static bool GetSyncedMetaData(string key, out uint result)
        {
            Core.GetSyncedMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueType.Uint)
                {
                    result = default;
                    return false;
                }

                result = (uint) mValue.GetUint();
            }

            return true;
        }

        public static bool GetSyncedMetaData(string key, out float result)
        {
            Core.GetSyncedMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueType.Double)
                {
                    result = default;
                    return false;
                }

                result = (float) mValue.GetDouble();
            }

            return true;
        }

        public static bool GetSyncedMetaData<T>(string key, out T result)
        {
            Core.GetSyncedMetaData(key, out var mValue);
            using (mValue)
            {
                if (!(mValue.ToObject() is T cast))
                {
                    result = default;
                    return false;
                }

                result = cast;
            }

            return true;
        }
    }
}