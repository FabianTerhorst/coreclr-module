using System;
using System.Threading;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Exceptions
{
    public class IllegalThreadException : Exception
    {
        public IllegalThreadException(IBaseObject baseObject, string callerName) : base(
            $"{callerName} from {baseObject} called in wrong thread with name {Thread.CurrentThread.Name} and id {Thread.CurrentThread.ManagedThreadId}")
        {
        }
        
        public IllegalThreadException(IServer baseObject, string callerName) : base(
            $"{callerName} from {baseObject} called in wrong thread with name {Thread.CurrentThread.Name} and id {Thread.CurrentThread.ManagedThreadId}")
        {
        }
    }
}