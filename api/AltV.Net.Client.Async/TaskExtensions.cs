namespace AltV.Net.Client.Async
{
    public static class TaskExtensions
    {
        public static async Task<T> ToMain<T>(this Task<T> task)
        {
            var result = await task;
            await AltAsync.ReturnToMainThread();
            return result;
        }
        
        public static async Task ToMain(this Task task)
        {
            await task;
            await AltAsync.ReturnToMainThread();
        }
    }
}