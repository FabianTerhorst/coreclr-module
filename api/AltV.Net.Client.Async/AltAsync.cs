using System.Diagnostics;

namespace AltV.Net.Client.Async
{
    public static partial class AltAsync
    {
        // internal static AsyncCore Core;

        internal static AltVAsync AltVAsync;

        // public static async void Log(string message)
        // {
        //     var messagePtr = AltNative.StringUtils.StringToHGlobalUtf8(message);
        //     await Do(() => Core.LogInfo(messagePtr));
        //     Marshal.FreeHGlobal(messagePtr);
        // }
        //
        // public static async void Emit(string eventName, params object[] args)
        // {
        //     var size = args.Length;
        //     var mValues = new MValueConst[size];
        //     Core.CreateMValues(mValues, args);
        //     var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
        //     await Do(() => Core.TriggerLocalEvent(eventNamePtr, mValues));
        //     Marshal.FreeHGlobal(eventNamePtr);
        //     for (var i = 0; i < size; i++)
        //     {
        //         mValues[i].Dispose();
        //     }
        // }
        //
        // public static async void EmitAllClients(string eventName, params object[] args)
        // {
        //     var size = args.Length;
        //     var mValues = new MValueConst[size];
        //     Core.CreateMValues(mValues, args);
        //     var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
        //     await Do(() => Core.TriggerClientEventForAll(eventNamePtr, mValues));
        //     Marshal.FreeHGlobal(eventNamePtr);
        //     for (var i = 0; i < size; i++)
        //     {
        //         mValues[i].Dispose();
        //     }
        // }

        [Conditional("DEBUG")]
        private static void CheckIfAsyncResource()
        {
            if (AltVAsync == null)
            {
                throw new InvalidOperationException(
                    "Resource doesn't extends AsyncResource. Please read https://fabianterhorst.github.io/coreclr-module/articles/async.html#setup-async-module");
            }
        }

        internal static void Setup(AltVAsync altVAsync)
        {
            AltVAsync = altVAsync;
        }

        // internal static void Setup(AsyncCore core)
        // {
        //     Core = core;
        // }

        public static Task Do(Action action)
        {
            CheckIfAsyncResource();
            return AltVAsync.Schedule(action);
        }
        
        public static Task Do(Task task)
        {
            throw new ArgumentException("AltAsync.Do should never have async code inside");
        }
        
        public static Task Do(Func<Task> task)
        {
            throw new ArgumentException("AltAsync.Do should never have async code inside");
        }
        
        public static void RunOnMainThreadBlocking(Action action, SemaphoreSlim semaphoreSlim)
        {
            CheckIfAsyncResource();
            AltVAsync.ScheduleBlocking(action, semaphoreSlim);
        }

        public static void RunOnMainThreadBlockingThrows(Action action, SemaphoreSlim semaphoreSlim)
        {
            CheckIfAsyncResource();
            AltVAsync.ScheduleBlockingThrows(action, semaphoreSlim);
        }

        public static Task Do(Action<object> action, object value)
        {
            CheckIfAsyncResource();
            return AltVAsync.Schedule(action, value);
        }

        public static Task<TResult> Do<TResult>(Func<TResult> action)
        {
            CheckIfAsyncResource();
            return AltVAsync.Schedule(action);
        }

        public static Task<TResult> Do<TResult>(Func<object, TResult> action, object value)
        {
            CheckIfAsyncResource();
            return AltVAsync.Schedule(action, value);
        }

        public static void RunOnMainThread(Action action)
        {
            CheckIfAsyncResource();
            AltVAsync.ScheduleNoneTask(action);
        }

        public static void RunOnMainThread(Action<object> action, object value)
        {
            CheckIfAsyncResource();
            AltVAsync.ScheduleNoneTask(action, value);
        }
    }
}