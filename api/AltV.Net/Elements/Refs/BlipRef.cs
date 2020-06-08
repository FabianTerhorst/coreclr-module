using System;
using System.Diagnostics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Refs
{
    public readonly struct BlipRef : IDisposable
    {
        private readonly IBlip blip;

        public bool Exists => blip != null;

        public BlipRef(IBlip blip)
        {
            this.blip = blip.AddRef() ? blip : null;
        }
        
        [Conditional("DEBUG")]
        public void DebugCountUp()
        {
            Alt.Module.CountUpRefForCurrentThread(blip);
        }

        [Conditional("DEBUG")]
        public void DebugCountDown()
        {
            Alt.Module.CountDownRefForCurrentThread(blip);
        }

        public void Dispose()
        {
            blip?.RemoveRef();
        }
    }
}