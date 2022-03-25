using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Events;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static Function OnServer(string eventName, Action action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1>(string eventName, Action<T1> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2>(string eventName, Action<T1, T2> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7> action) => Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1>(string eventName, Func<T1> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2>(string eventName, Func<T1, T2> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3>(string eventName, Func<T1, T2, T3> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7> action) => Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> action) => Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Core.OnServer(eventName, Function.Create(action));

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> action) =>
            Core.OnServer(eventName, Function.Create(action));


        public static Function OnClient(string eventName, Action action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1>(string eventName, Action<T1> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2>(string eventName, Action<T1, T2> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7> action) => Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1>(string eventName, Func<T1> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2>(string eventName, Func<T1, T2> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3>(string eventName, Func<T1, T2, T3> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7> action) => Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8> action) => Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            string eventName,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> action) =>
            Core.OnClient(eventName, Function.Create(action));
        
        public static Function OnClient(string eventName, Action<IPlayer> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1>(string eventName, Action<IPlayer, T1> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2>(string eventName, Action<IPlayer, T1, T2> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3>(string eventName, Action<IPlayer, T1, T2, T3> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4>(string eventName, Action<IPlayer, T1, T2, T3, T4> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5>(string eventName, Action<IPlayer, T1, T2, T3, T4, T5> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Action<IPlayer, T1, T2, T3, T4, T5, T6> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7> action) => Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8> action) => Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1>(string eventName, Func<IPlayer, T1> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2>(string eventName, Func<IPlayer, T1, T2> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3>(string eventName, Func<IPlayer, T1, T2, T3> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4>(string eventName, Func<IPlayer, T1, T2, T3, T4> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5>(string eventName, Func<IPlayer, T1, T2, T3, T4, T5> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Func<IPlayer, T1, T2, T3, T4, T5, T6> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7> action) => Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8> action) => Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) =>
            Core.OnClient(eventName, Function.Create(action));

        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            string eventName,
            Func<IPlayer, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) =>
            Core.OnClient(eventName, Function.Create(action));
    }
}