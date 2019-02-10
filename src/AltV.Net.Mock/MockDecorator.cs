using System;
using System.Linq;
using System.Reflection;

namespace AltV.Net.Mock
{
    public class MockDecorator<T, TM> : DispatchProxy
    {
        private T decorated;

        private TM mock;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            try
            {
                LogBefore(targetMethod, args);

                var mockMethod = mock.GetType().GetMethods()
                    .FirstOrDefault(info => info.Name == targetMethod.Name);
                var result = mockMethod != null ? mockMethod.Invoke(mock, args) : targetMethod.Invoke(decorated, args);
                
                LogAfter(targetMethod, args, result);
                return result;
            }
            catch (Exception ex) when (ex is TargetInvocationException)
            {
                LogException(ex.InnerException ?? ex, targetMethod);
                throw ex.InnerException ?? ex;
            }
        }

        public static T Create(T decorated, TM mock)
        {
            object proxy = Create<T, MockDecorator<T, TM>>();
            ((MockDecorator<T, TM>) proxy).SetParameters(decorated, mock);

            return (T) proxy;
        }

        private void SetParameters(T decorated, TM mock)
        {
            if (decorated == null || mock == null)
            {
                throw new ArgumentNullException(nameof(decorated));
            }

            this.decorated = decorated;
            this.mock = mock;
        }

        private void LogException(Exception exception, MethodInfo methodInfo = null)
        {
            Console.WriteLine(
                $"Class {decorated.GetType().FullName}, Method {methodInfo.Name} threw exception:\n{exception}");
        }

        private void LogAfter(MethodInfo methodInfo, object[] args, object result)
        {
            Console.WriteLine(
                $"Class {decorated.GetType().FullName}, Method {methodInfo.Name} executed, Output: {result}");
        }

        private void LogBefore(MethodInfo methodInfo, object[] args)
        {
            Console.WriteLine($"Class {decorated.GetType().FullName}, Method {methodInfo.Name} is executing");
        }
    }
}