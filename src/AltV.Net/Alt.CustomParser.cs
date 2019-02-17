using System;
using AltV.Net.FunctionParser;

namespace AltV.Net
{
    public partial class Alt
    {
        public static void On(string eventName, Action action, ClientEventParser<Action> parser) =>
            Module.On(eventName, action, parser);

        public static void
            On<T1, T2>(string eventName, Action<T1, T2> action, ClientEventParser<Action<T1, T2>> parser) =>
            Module.On(eventName, action, parser);

        public static void On<T1, T2, T3>(string eventName, Action<T1, T2, T3> action,
            ClientEventParser<Action<T1, T2, T3>> parser) => Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action,
            ClientEventParser<Action<T1, T2, T3, T4>> parser) => Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action,
            ClientEventParser<Action<T1, T2, T3, T4, T5>> parser) => Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action,
            ClientEventParser<Action<T1, T2, T3, T4, T5, T6>> parser) => Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4, T5, T6, T7>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7> action,
            ClientEventParser<Action<T1, T2, T3, T4, T5, T6, T7>> parser) => Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action,
            ClientEventParser<Action<T1, T2, T3, T4, T5, T6, T7, T8>> parser) => Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action,
            ClientEventParser<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> parser) =>
            Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action,
            ClientEventParser<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> parser) =>
            Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action,
            ClientEventParser<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> parser) =>
            Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action,
            ClientEventParser<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> parser) =>
            Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action,
            ClientEventParser<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> parser) =>
            Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
            ClientEventParser<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> parser) =>
            Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action,
            ClientEventParser<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> parser) =>
            Module.On(eventName, action, parser);

        public static void On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action,
            ClientEventParser<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> parser) =>
            Module.On(eventName, action, parser);
    }
}