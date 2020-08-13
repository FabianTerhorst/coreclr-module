using System.Diagnostics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public struct AsyncBaseObjectRef
    {
        private readonly IBaseObject baseObject;

        public bool Exists => baseObject != null;

        public AsyncBaseObjectRef(IBaseObject baseObject)
        {
            if (baseObject == null)
            {
                this.baseObject = null;
            }
            else
            {
                lock (baseObject)
                {
                    this.baseObject = baseObject.AddRef() ? baseObject : null;
                }
            }
        }

        [Conditional("DEBUG")]
        public void DebugCountUp()
        {
            Alt.Module.CountUpRefForCurrentThread(baseObject);
        }

        [Conditional("DEBUG")]
        public void DebugCountDown()
        {
            Alt.Module.CountDownRefForCurrentThread(baseObject);
        }

        public void Dispose()
        {
            baseObject?.RemoveRef();
        }
    }
}