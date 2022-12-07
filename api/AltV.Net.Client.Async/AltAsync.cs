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

        public class MainThreadContext : IAsyncDisposable
        {
            public async ValueTask DisposeAsync()
            {
                if (!Alt.Core.IsMainThread()) throw new Exception("ReturnToMainThread using block was exited on a non-main thread");
                await Task.Run(() => {}); // jump to bg thread
            }

            private MainThreadContext()
            {
            }
            
            internal static readonly MainThreadContext Instance = new();
        }

        public static async Task<MainThreadContext> ReturnToMainThread()
        {
            if (Alt.Core.IsMainThread()) return MainThreadContext.Instance;
            var source = new TaskCompletionSource();
            RunOnMainThread(() => source.SetResult());
            await source.Task;
            return MainThreadContext.Instance;
        }
        
        
        public static async Task WaitFor(Func<bool> fn, uint timeout = 2000, uint interval = 0)
        {
            var checkUntil = DateTime.Now.AddMilliseconds(timeout);
            var source = new TaskCompletionSource<bool>();
            uint handle = 0;
            handle = Alt.SetInterval(() =>
            {
                if (fn())
                {
                    source.SetResult(true);
                    Alt.ClearInterval(handle);
                    return;
                }

                if (DateTime.Now <= checkUntil) return;
                source.SetException(new TimeoutException("Failed to wait for callback"));
                Alt.ClearInterval(handle);
            }, interval);
            
            await source.Task;
        }
    }
}