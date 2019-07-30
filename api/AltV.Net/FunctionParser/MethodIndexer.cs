using System;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AltV.Net.Async")]
namespace AltV.Net.FunctionParser
{
    internal static class MethodIndexer
    {
        internal static void Index<T>(object target, Action<string, Function> found) where T : Event
        {
            var eventMethods = target.GetType().GetMethods()
                .Where(m => m.GetCustomAttributes(typeof(T), false).Length > 0).ToArray();
            foreach (var eventMethod in eventMethods)
            {
                var eventAttributes = eventMethod.GetCustomAttributes(typeof(T), false);
                if (eventAttributes.Length <= 0) continue;
                var eventAttributeObj = eventAttributes[0];
                if (!(eventAttributeObj is T eventAttribute)) continue;
                var eventName = eventAttribute.Name ?? eventMethod.Name;
                found(eventName, Function.Create(eventMethod.CreateDelegate(target)));
            }
        }
    }
}