using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public readonly struct AsyncBlipRef : IDisposable
    {
        private readonly IBlip blip;

        public bool Exists => blip != null;

        public AsyncBlipRef(IBlip blip)
        {
            lock (blip)
            {
                if (blip.Exists) {
                    this.blip = blip.AddRef() ? blip : null;
                    Alt.Module.CountUpRefForCurrentThread(blip);
                }
                else
                {
                    this.blip = null;
                }
            }
        }

        public void Dispose()
        {
            if (blip == null) return;
            lock (blip)
            {
                if (blip.Exists)
                {
                    blip.RemoveRef();
                }
            }

            Alt.Module.CountDownRefForCurrentThread(blip);
        }
    }
}