using System;
using System.Threading;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Exceptions
{
    public class IllegalThreadException : Exception
    {
        public IllegalThreadException(ISharedBaseObject baseObject, string callerName) : base(
            $"{callerName} from {baseObject} called in wrong thread with name {Thread.CurrentThread.Name} and id {Thread.CurrentThread.ManagedThreadId}")
        {
        }
        
        public IllegalThreadException(ISharedCore baseObject, string callerName) : base(
            $"{callerName} from {baseObject} called in wrong thread with name {Thread.CurrentThread.Name} and id {Thread.CurrentThread.ManagedThreadId}")
        {
        }
        public IllegalThreadException(ISharedBaseObject baseObject) : base(
            $"API from {baseObject} called in wrong thread with name {Thread.CurrentThread.Name} and id {Thread.CurrentThread.ManagedThreadId}")
        {
        }
        
        public IllegalThreadException(ISharedCore baseObject) : base(
            $"API from {baseObject} called in wrong thread with name {Thread.CurrentThread.Name} and id {Thread.CurrentThread.ManagedThreadId}")
        {
        }
    }
}