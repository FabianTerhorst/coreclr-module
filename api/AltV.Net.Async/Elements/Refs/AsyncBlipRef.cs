using System;
using System.Diagnostics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public readonly struct AsyncBlipRef : IDisposable
    {
        private readonly IBlip blip;

        public bool Exists => blip != null;

        public AsyncBlipRef(IBlip blip)
        {
            if (blip == null)
            {
                this.blip = null;
            }
            else
            {
                lock (blip)
                {
                    this.blip = blip.AddRef() ? blip : null;
                }
            }
        }

        [Conditional("DEBUG")]
        public void DebugCountUp()
        {
            Alt.CoreImpl.CountUpRefForCurrentThread(blip);
        }

        [Conditional("DEBUG")]
        public void DebugCountDown()
        {
            Alt.CoreImpl.CountDownRefForCurrentThread(blip);
        }

        public void Dispose()
        {
            blip?.RemoveRef();
        }
    }
}