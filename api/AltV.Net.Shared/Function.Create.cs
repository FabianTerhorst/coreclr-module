using System;

namespace AltV.Net
{
    public partial class Function
    {
        public static Function Create(Action function)
        {
            return Create<Action>(function);
        }

        public static Function Create<T1>(Action<T1> function)
        {
            return Create<Action<T1>>(function);
        }

        public static Function Create<T1, T2>(Action<T1, T2> function)
        {
            return Create<Action<T1, T2>>(function);
        }

        public static Function Create<T1, T2, T3>(Action<T1, T2, T3> function)
        {
            return Create<Action<T1, T2, T3>>(function);
        }

        public static Function Create<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function)
        {
            return Create<Action<T1, T2, T3, T4>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> function)
        {
            return Create<Action<T1, T2, T3, T4, T5>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(function);
        }

        public static Function Create<T1>(Func<T1> function)
        {
            return Create<Func<T1>>(function);
        }

        public static Function Create<T1, T2>(Func<T1, T2> function)
        {
            return Create<Func<T1, T2>>(function);
        }

        public static Function Create<T1, T2, T3>(Func<T1, T2, T3> function)
        {
            return Create<Func<T1, T2, T3>>(function);
        }

        public static Function Create<T1, T2, T3, T4>(Func<T1, T2, T3, T4> function)
        {
            return Create<Func<T1, T2, T3, T4>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5> function)
        {
            return Create<Func<T1, T2, T3, T4, T5>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>>(
                function);
        }
    }
}