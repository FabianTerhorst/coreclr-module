using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AltV.Net.Async")]

namespace AltV.Net.FunctionParser
{
    internal static class MethodIndexer
    {
        internal static void Index(object target, Type[] customAttributes, Action<object, MethodInfo, Delegate> found)
        {
            var eventMethods = target.GetType().GetMethods();
            var attributeMethods = new LinkedList<(MethodInfo, object[])>();
            for (int i = 0, length = eventMethods.Length; i < length; i++)
            {
                var m = eventMethods[i];
                for (int j = 0, attributesLength = customAttributes.Length; j < attributesLength; j++)
                {
                    var customAttribute = customAttributes[j];
                    var methodCustomAttributes = m.GetCustomAttributes(customAttribute, false);
                    if (methodCustomAttributes.Length <= 0) continue;
                    attributeMethods.AddFirst((m, methodCustomAttributes));
                }
            }

            foreach (var (eventMethod, eventAttributes) in attributeMethods)
            {
                foreach (var eventAttribute in eventAttributes)
                {
                    found(eventAttribute, eventMethod, eventMethod.CreateDelegate(target));
                }
            }
        }
    }
}