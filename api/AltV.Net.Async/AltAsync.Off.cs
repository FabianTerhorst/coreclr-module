using System;
using AltV.Net.Async.Events;

namespace AltV.Net.Async
{
    public partial class AltAsync
    {
        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off(string eventName, Function function) => Module.Off(eventName, function);

        [Obsolete("This method is obsolete. Use AltAsync.OffClient instead.")]
        public static void OffClient(string eventName, ClientEventAsyncDelegate clientEventDelegate)
        {
            Module.OffClient(eventName, clientEventDelegate);
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer instead.")]
        public static void OffServer(string eventName, ServerEventAsyncDelegate serverEventDelegate)
        {
            Module.OffServer(eventName, serverEventDelegate);
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off(string eventName, Action function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T>(string eventName, Action<T> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2>(string eventName, Action<T1, T2> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3>(string eventName, Action<T1, T2, T3> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T>(string eventName, Func<T> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2>(string eventName, Func<T1, T2> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3>(string eventName, Func<T1, T2, T3> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        [Obsolete("This method is obsolete. Use AltAsync.OffServer or AltAsync.OffClient instead.")]
        public static void Off<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> function)
        {
            Module.Off(eventName, Function.Create(function));
        }

        public static void OffServer(string eventName, Action action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1>(string eventName, Action<T1> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2>(string eventName, Action<T1, T2> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7> action) => Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1>(string eventName, Func<T1> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2>(string eventName, Func<T1, T2> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3>(string eventName, Func<T1, T2, T3> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7> action) => Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> action) => Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Module.OffServer(eventName, Function.Create(action));

        public static void OffServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> action) =>
            Module.OffServer(eventName, Function.Create(action));


        public static void OffClient(string eventName, Action action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1>(string eventName, Action<T1> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2>(string eventName, Action<T1, T2> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7> action) => Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1>(string eventName, Func<T1> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2>(string eventName, Func<T1, T2> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3>(string eventName, Func<T1, T2, T3> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7> action) => Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> action) => Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Module.OffClient(eventName, Function.Create(action));

        public static void OffClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> action) =>
            Module.OffClient(eventName, Function.Create(action));
    }
}