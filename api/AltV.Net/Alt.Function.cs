using System;
using AltV.Net.Shared;

namespace AltV.Net
{
    public partial class Alt
    {
        public static Function CreateFunction<T>(T func) where T : Delegate
        {
            return Function.Create(Core, func);
        }
        
        public static Function CreateFunction(Action function)
        {
            return Function.Create<Action>(Core, function);
        }

        public static Function CreateFunction<T1>(Action<T1> function)
        {
            return Function.Create<Action<T1>>(Core, function);
        }

        public static Function CreateFunction<T1, T2>(Action<T1, T2> function)
        {
            return Function.Create<Action<T1, T2>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3>(Action<T1, T2, T3> function)
        {
            return Function.Create<Action<T1, T2, T3>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function)
        {
            return Function.Create<Action<T1, T2, T3, T4>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> function)
        {
            return Function.Create<Action<T1, T2, T3, T4, T5>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> function)
        {
            return Function.Create<Action<T1, T2, T3, T4, T5, T6>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> function)
        {
            return Function.Create<Action<T1, T2, T3, T4, T5, T6, T7>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            return Function.Create<Action<T1, T2, T3, T4, T5, T6, T7, T8>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            return Function.Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            return Function.Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            return Function.Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            return Function.Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            return Function.Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            return Function.Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            return Function.Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            return Function.Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(Core, function);
        }

        public static Function CreateFunction<T1>(Func<T1> function)
        {
            return Function.Create<Func<T1>>(Core, function);
        }

        public static Function CreateFunction<T1, T2>(Func<T1, T2> function)
        {
            return Function.Create<Func<T1, T2>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3>(Func<T1, T2, T3> function)
        {
            return Function.Create<Func<T1, T2, T3>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4>(Func<T1, T2, T3, T4> function)
        {
            return Function.Create<Func<T1, T2, T3, T4>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5, T6>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5, T6, T7>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5, T6, T7, T8>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(Core, function);
        }

        public static Function CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function)
        {
            return Function.Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>>(Core, 
                function);
        }
    }
}