using System;
using AltV.Net.Async.Events;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On(string eventName, Function function) => Module.On(eventName, function);

        [Obsolete("This method is obsolete. Use AltAsync.OnClient instead.")]
        public static void OnClient(string eventName, ClientEventAsyncDelegate clientEventDelegate)
        {
            Module.OnClient(eventName, clientEventDelegate);
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer instead.")]
        public static void OnServer(string eventName, ServerEventAsyncDelegate serverEventDelegate)
        {
            Module.OnServer(eventName, serverEventDelegate);
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On(string eventName, Action function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T>(string eventName, Action<T> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2>(string eventName, Action<T1, T2> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3>(string eventName, Action<T1, T2, T3> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T>(string eventName, Func<T> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2>(string eventName, Func<T1, T2> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3>(string eventName, Func<T1, T2, T3> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OnServer or AltAsync.OnClient instead.")]
        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function)
        {
            Module.On(eventName, Function.Create(function));
        }

        public static void OnServer(string eventName, Action action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1>(string eventName, Action<T1> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2>(string eventName, Action<T1, T2> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7> action) => Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1>(string eventName, Func<T1> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2>(string eventName, Func<T1, T2> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3>(string eventName, Func<T1, T2, T3> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7> action) => Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> action) => Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Module.OnServer(eventName, Function.Create(action));

        public static void OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> action) =>
            Module.OnServer(eventName, Function.Create(action));


        public static void OnClient(string eventName, Action action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1>(string eventName, Action<T1> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2>(string eventName, Action<T1, T2> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7> action) => Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1>(string eventName, Func<T1> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2>(string eventName, Func<T1, T2> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3>(string eventName, Func<T1, T2, T3> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7> action) => Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> action) => Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> action) =>
            Module.OnClient(eventName, Function.Create(action));
    }
}