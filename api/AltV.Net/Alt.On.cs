using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Events;

namespace AltV.Net
{
    public static partial class Alt
    {
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
        
        public static void OnClient(string eventName, Action<IPlayer> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1>(string eventName, Action<IPlayer, T1> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2>(string eventName, Action<IPlayer, T1, T2> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3>(string eventName, Action<IPlayer, T1, T2, T3> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4>(string eventName, Action<IPlayer, T1, T2, T3, T4> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5>(string eventName, Action<IPlayer, T1, T2, T3, T4, T5> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Action<IPlayer, T1, T2, T3, T4, T5, T6> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7> action) => Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8> action) => Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1>(string eventName, Func<IPlayer, T1> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2>(string eventName, Func<IPlayer, T1, T2> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3>(string eventName, Func<IPlayer, T1, T2, T3> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4>(string eventName, Func<IPlayer, T1, T2, T3, T4> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5>(string eventName, Func<IPlayer, T1, T2, T3, T4, T5> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Func<IPlayer, T1, T2, T3, T4, T5, T6> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7> action) => Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8> action) => Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Module.OnClient(eventName, Function.Create(action));

        public static void OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Module.OnClient(eventName, Function.Create(action));
    }
}