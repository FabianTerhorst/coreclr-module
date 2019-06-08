using System;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net
{
    public partial class Alt
    {
        public static bool Import(string resourceName, string key, out bool value)
        {
            if (!Import(resourceName, key, MValue.Type.BOOL, out var mValue))
            {
                value = default;
                return false;
            }

            value = mValue.GetBool();
            return true;
        }

        public static bool Import(string resourceName, string key, out int value)
        {
            if (!Import(resourceName, key, MValue.Type.INT, out var mValue))
            {
                value = default;
                return false;
            }

            value = (int) mValue.GetInt();
            return true;
        }

        public static bool Import(string resourceName, string key, out long value)
        {
            if (!Import(resourceName, key, MValue.Type.INT, out var mValue))
            {
                value = default;
                return false;
            }

            value = mValue.GetInt();
            return true;
        }

        public static bool Import(string resourceName, string key, out uint value)
        {
            if (!Import(resourceName, key, MValue.Type.UINT, out var mValue))
            {
                value = default;
                return false;
            }

            value = (uint) mValue.GetUint();
            return true;
        }

        public static bool Import(string resourceName, string key, out ulong value)
        {
            if (!Import(resourceName, key, MValue.Type.UINT, out var mValue))
            {
                value = default;
                return false;
            }

            value = mValue.GetUint();
            return true;
        }

        public static bool Import(string resourceName, string key, out double value)
        {
            if (!Import(resourceName, key, MValue.Type.DOUBLE, out var mValue))
            {
                value = default;
                return false;
            }

            value = mValue.GetDouble();
            return true;
        }

        public static bool Import(string resourceName, string key, out string value)
        {
            if (!Import(resourceName, key, MValue.Type.STRING, out var mValue))
            {
                value = null;
                return false;
            }

            value = mValue.GetString();
            return true;
        }

        public static bool Import(string resourceName, string key, out MValue mValue)
        {
            var resource = Server.GetResource(resourceName);
            if (resource == null)
            {
                mValue = default;
                throw new InvalidImportException(
                    $"Resource: '{resourceName}' not found.");
            }

            mValue = MValue.Nil;
            if (!resource.GetExport(key, ref mValue))
            {
                throw new InvalidImportException(
                    $"Resource: '{resourceName}' doesn't contains a export with the name: '{key}'.");
            }

            return true;
        }

        public static bool Import(string resourceName, string key, MValue.Type type, out MValue mValue)
        {
            if (Import(resourceName, key, out mValue) && mValue.type == type)
            {
                return true;
            }

            throw new InvalidImportException(
                $"Resource: '{resourceName}.{key}' with type: '{mValue.type}' doesn't matches the expected export type: '{type}'.");
        }

        private static MValue ImportCall(MValue mValue, object[] args)
        {
            //var mValueArgs = MValue.CreateFromObject(args);
            var result = MValue.Nil;
            var length = (ulong) args.Length;
            var mValueArgs = new MValue[length];
            for (uint i = 0; i < length; i++)
            {
                mValueArgs[i] = MValue.CreateFromObject(args[i]);
            }

            //AltNative.MValueCall.MValue_CallFunctionValue(ref mValue, ref mValueArgs, ref result);
            AltNative.MValueCall.MValue_CallFunction(ref mValue, mValueArgs, length, ref result);
            return result;
        }

        public static bool Import(string resourceName, string key, out Action value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = () => { ImportCall(mValue, new object[] { }); };
            return true;
        }

        public static bool Import<T1>(string resourceName, string key, out Action<T1> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1) => { ImportCall(mValue, new object[] {p1}); };
            return true;
        }

        public static bool Import<T1, T2>(string resourceName, string key, out Action<T1, T2> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2) => { ImportCall(mValue, new object[] {p1, p2}); };
            return true;
        }

        public static bool Import<T1, T2, T3>(string resourceName, string key, out Action<T1, T2, T3> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3) => { ImportCall(mValue, new object[] {p1, p2, p3}); };
            return true;
        }

        public static bool Import<T1, T2, T3, T4>(string resourceName, string key, out Action<T1, T2, T3, T4> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4) => { ImportCall(mValue, new object[] {p1, p2, p3, p4}); };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5>(string resourceName, string key,
            out Action<T1, T2, T3, T4, T5> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5) => { ImportCall(mValue, new object[] {p1, p2, p3, p4, p5}); };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6>(string resourceName, string key,
            out Action<T1, T2, T3, T4, T5, T6> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6) => { ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6}); };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7>(string resourceName, string key,
            out Action<T1, T2, T3, T4, T5, T6, T7> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7) => { ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7}); };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8>(string resourceName, string key,
            out Action<T1, T2, T3, T4, T5, T6, T7, T8> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8) =>
            {
                ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8});
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string resourceName, string key,
            out Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9) =>
            {
                ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9});
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string resourceName, string key,
            out Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) =>
            {
                ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10});
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string resourceName, string key,
            out Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) =>
            {
                ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11});
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string resourceName, string key,
            out Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) =>
            {
                ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12});
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string resourceName,
            string key,
            out Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) =>
            {
                ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13});
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string resourceName,
            string key,
            out Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) =>
            {
                ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14});
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string resourceName,
            string key,
            out Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) =>
            {
                ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15});
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string resourceName, string key,
            out Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16) =>
            {
                ImportCall(mValue,
                    new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16});
            };
            return true;
        }

        public static bool Import<TResult>(string resourceName, string key, out Func<TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = () =>
            {
                if (ImportCall(mValue, new object[] { }) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, TResult>(string resourceName, string key, out Func<T1, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1) =>
            {
                if (ImportCall(mValue, new object[] {p1}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, TResult>(string resourceName, string key, out Func<T1, T2, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, TResult>(string resourceName, string key,
            out Func<T1, T2, T3, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2, p3}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, TResult>(string resourceName, string key,
            out Func<T1, T2, T3, T4, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2, p3, p4}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, TResult>(string resourceName, string key,
            out Func<T1, T2, T3, T4, T5, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2, p3, p4, p5}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, TResult>(string resourceName, string key,
            out Func<T1, T2, T3, T4, T5, T6, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, TResult>(string resourceName, string key,
            out Func<T1, T2, T3, T4, T5, T6, T7, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(string resourceName, string key,
            out Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(string resourceName, string key,
            out Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(string resourceName, string key,
            out Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(string resourceName,
            string key,
            out Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(string resourceName,
            string key,
            out Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12}) is TResult
                    result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(string resourceName,
            string key,
            out Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13}) is TResult
                    result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            string resourceName, string key,
            out Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) =>
            {
                if (ImportCall(mValue, new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14}) is
                    TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            string resourceName, string key,
            out Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) =>
            {
                if (ImportCall(mValue,
                    new object[] {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }

        public static bool Import<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string resourceName, string key,
            out Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> value)
        {
            if (!Import(resourceName, key, MValue.Type.FUNCTION, out var mValue))
            {
                value = default;
                return false;
            }

            value = (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16) =>
            {
                if (ImportCall(mValue,
                    new object[]
                        {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16}) is TResult result)
                {
                    return result;
                }

                return default;
            };
            return true;
        }
    }
}