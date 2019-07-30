using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AltV.Net.FunctionParser
{
    internal static class DelegateUtils
    {
        internal static Delegate CreateDelegate(this MethodInfo methodInfo, object target)
        {
            Func<Type[], Type> getType;
            var isAction = methodInfo.ReturnType == typeof(void);
            var types = methodInfo.GetParameters().Select(p => p.ParameterType);

            if (isAction)
            {
                getType = Expression.GetActionType;
            }
            else
            {
                getType = Expression.GetFuncType;
                types = types.Concat(new[] {methodInfo.ReturnType});
            }

            return methodInfo.IsStatic
                ? Delegate.CreateDelegate(getType(types.ToArray()), methodInfo)
                : Delegate.CreateDelegate(getType(types.ToArray()), target, methodInfo.Name);
        }
    }
}