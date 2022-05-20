using System;
using AltV.Net.Shared;

namespace AltV.Net
{
    public partial class Function
    {
        public static Function Create(ISharedCore core, Action function)
        {
            return Create<Action>(core, function);
        }

        public static Function Create<T1>(ISharedCore core, Action<T1> function)
        {
            return Create<Action<T1>>(core, function);
        }

        public static Function Create<T1, T2>(ISharedCore core, Action<T1, T2> function)
        {
            return Create<Action<T1, T2>>(core, function);
        }

        public static Function Create<T1, T2, T3>(ISharedCore core, Action<T1, T2, T3> function)
        {
            return Create<Action<T1, T2, T3>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4>(ISharedCore core, Action<T1, T2, T3, T4> function)
        {
            return Create<Action<T1, T2, T3, T4>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5>(ISharedCore core, Action<T1, T2, T3, T4, T5> function)
        {
            return Create<Action<T1, T2, T3, T4, T5>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6>(ISharedCore core, Action<T1, T2, T3, T4, T5, T6> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7>(ISharedCore core, Action<T1, T2, T3, T4, T5, T6, T7> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8>(ISharedCore core, Action<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ISharedCore core, 
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ISharedCore core, 
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ISharedCore core, 
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ISharedCore core, 
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ISharedCore core, 
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ISharedCore core, 
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ISharedCore core, 
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ISharedCore core, 
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(core, function);
        }

        public static Function Create<T1>(ISharedCore core, Func<T1> function)
        {
            return Create<Func<T1>>(core, function);
        }

        public static Function Create<T1, T2>(ISharedCore core, Func<T1, T2> function)
        {
            return Create<Func<T1, T2>>(core, function);
        }

        public static Function Create<T1, T2, T3>(ISharedCore core, Func<T1, T2, T3> function)
        {
            return Create<Func<T1, T2, T3>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4>(ISharedCore core, Func<T1, T2, T3, T4> function)
        {
            return Create<Func<T1, T2, T3, T4>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5>(ISharedCore core, Func<T1, T2, T3, T4, T5> function)
        {
            return Create<Func<T1, T2, T3, T4, T5>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6>(ISharedCore core, Func<T1, T2, T3, T4, T5, T6> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7>(ISharedCore core, Func<T1, T2, T3, T4, T5, T6, T7> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8>(ISharedCore core, Func<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ISharedCore core, 
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ISharedCore core, 
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ISharedCore core, 
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ISharedCore core, 
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ISharedCore core, 
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ISharedCore core, 
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ISharedCore core, 
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ISharedCore core, 
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(core, function);
        }

        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(ISharedCore core, 
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function)
        {
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>>(core, 
                function);
        }
        
        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create(Action function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1>(Action<T1> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2>(Action<T1, T2> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3>(Action<T1, T2, T3> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4>>(AltShared.Core, function);
        }
        
        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4, T5>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4, T5, T6>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4, T5, T6, T7>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1>(Func<T1> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2>(Func<T1, T2> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3>(Func<T1, T2, T3> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4>(Func<T1, T2, T3, T4> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5, T6>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5, T6, T7>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(AltShared.Core, function);
        }

        [Obsolete("Use Alt.CreateFunction or overload with ISharedCore argument instead")]
        public static Function Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function)
        {
            AltShared.Core.LogWarning("Function.Create is deprecated, use Alt.CreateFunction or overload with ISharedCore argument instead");
            return Create<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>>(AltShared.Core,
                function);
        }
    }
}