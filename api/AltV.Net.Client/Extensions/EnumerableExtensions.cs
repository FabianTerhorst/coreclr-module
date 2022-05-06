using System.Reflection;

namespace AltV.Net.Client.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEachCatching<T>(this IEnumerable<T> enumerable, Action<T> action, string exceptionLocation)
        {
            foreach (var item in enumerable)
            {
                try
                {
                    action(item);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log($"Exception at {exceptionLocation}: {exception.InnerException}");
                }
                catch (Exception exception)
                {
                    Alt.Log($"Exception at {exceptionLocation}: {exception}");
                }
            }
        }
    }
}