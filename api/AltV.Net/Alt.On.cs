using System;
using AltV.Net.Events;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static void On(string eventName, Function function) => Module.On(eventName, function);

        public static void OnClient(string eventName, ClientEventDelegate clientEventDelegate)
        {
            Module.OnClient(eventName, clientEventDelegate);
        }

        public static void OnServer(string eventName, ServerEventDelegate serverEventDelegate)
        {
            Module.OnServer(eventName, serverEventDelegate);
        }

        public static void On(string eventName, Action function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T>(string eventName, Action<T> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2>(string eventName, Action<T1, T2> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3>(string eventName, Action<T1, T2, T3> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T>(string eventName, Func<T> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2>(string eventName, Func<T1, T2> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3>(string eventName, Func<T1, T2, T3> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function)
        {
            Module.On(eventName, Function.Create(function));
        }
    }
}