using System.Diagnostics;
using AltV.Net.Elements.Entities;
using AltV.Net.Types;

namespace AltV.Net.Elements.Refs
{
    public struct BaseObjectRef
    {
        private readonly IRefCountable baseObject;

        public bool Exists => baseObject != null;

        public BaseObjectRef(IRefCountable baseObject)
        {
            this.baseObject = baseObject?.AddRef() == true ? baseObject : null;
        }
        
        [Conditional("DEBUG")]
        public void DebugCountUp()
        {
            Alt.CoreImpl.CountUpRefForCurrentThread(baseObject);
        }

        [Conditional("DEBUG")]
        public void DebugCountDown()
        {
            Alt.CoreImpl.CountDownRefForCurrentThread(baseObject);
        }

        public void Dispose()
        {
            baseObject?.RemoveRef();
        }
    }
}