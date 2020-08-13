using System.Diagnostics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Refs
{
    public struct BaseObjectRef
    {
        private readonly IBaseObject baseObject;

        public bool Exists => baseObject != null;

        public BaseObjectRef(IBaseObject baseObject)
        {
            this.baseObject = baseObject?.AddRef() == true ? baseObject : null;
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