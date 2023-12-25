using AltV.Net.Elements.Args;

namespace AltV.Net.Client
{
    public partial class Alt
    {
        public static void SetMetaData(string key, object value) => Core.SetMetaData(key, value);

        public static bool HasMetaData(string key) => Core.HasMetaData(key);

        public static void DeleteMetaData(string key) => Core.DeleteMetaData(key);

        public static bool HasLocalMetaData(string key) => Core.HasLocalMetaData(key);

        public static bool GetMetaData(string key, out int result)
        {
            Core.GetMetaData(key, out var mValue);
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
            Core.GetMetaData(key, out var mValue);
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
            Core.GetMetaData(key, out var mValue);
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
            Core.GetMetaData(key, out var mValue);
            using (mValue)
            {

                try
                {
                    result = (T)Convert.ChangeType(mValue.ToObject(), typeof(T));
                    return true;
                }
                catch
                {
                    result = default;
                    return false;
                }
            }
        }

        public static bool GetSyncedMetaData<T>(string key, out T result)
        {
            Core.GetSyncedMetaData(key, out var mValue);
            using (mValue)
            {

                try
                {
                    result = (T)Convert.ChangeType(mValue.ToObject(), typeof(T));
                    return true;
                }
                catch
                {
                    result = default;
                    return false;
                }
            }
        }

        public static bool GetLocalMetaData<T>(string key, out T result)
        {
            Core.GetLocalMetaData<T>(key, out var mValue);
            using (mValue)
            {

                try
                {
                    result = (T)Convert.ChangeType(mValue.ToObject(), typeof(T));
                    return true;
                }
                catch
                {
                    result = default;
                    return false;
                }
            }
        }
    }
}