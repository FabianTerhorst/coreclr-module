using AltV.Net.Elements.Args;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static void SetMetaData(string key, object value) => Server.SetMetaData(key, value);
        
        public static bool HasMetaData(string key) => Server.HasMetaData(key);

        public static void DeleteMetaData(string key) => Server.DeleteMetaData(key);
        
        public static bool GetMetaData(string key, out int result)
        {
            Server.GetMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Int)
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
            Server.GetMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Uint)
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
            Server.GetMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Double)
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
            Server.GetMetaData(key, out var mValue);
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
        
        public static void SetSyncedMetaData(string key, object value) => Server.SetSyncedMetaData(key, value);
        
        public static bool HasSyncedMetaData(string key) => Server.HasSyncedMetaData(key);

        public static void DeleteSyncedMetaData(string key) => Server.DeleteSyncedMetaData(key);
        
        public static bool GetSyncedMetaData(string key, out int result)
        {
            Server.GetSyncedMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Int)
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
            Server.GetSyncedMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Uint)
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
            Server.GetSyncedMetaData(key, out var mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Double)
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
            Server.GetSyncedMetaData(key, out var mValue);
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