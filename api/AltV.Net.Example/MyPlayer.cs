using System;
using AltV.Net.Async;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    public interface IMyPlayer : IPlayer, IAsyncConvertible<IMyPlayer>
    {
        int MyData { get; set; }
    }

    public class MyPlayer : Player, IMyPlayer
    {
        private class Async : AsyncPlayer<IMyPlayer>, IMyPlayer
        {
            public int MyData
            {
                get => BaseObject.MyData;
                set => BaseObject.MyData = value;
            }

            public Async(IMyPlayer player, IAsyncContext asyncContext) : base(player, asyncContext)
            {
            }

            public IMyPlayer ToAsync(IAsyncContext asyncContext)
            {
                return asyncContext == AsyncContext ? this : new Async(BaseObject, asyncContext);
            }
            
            public IMyPlayer ToAsync()
            {
                return this;
            }
        }

        public int MyData { get; set; }

        public MyPlayer(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
        {
            MyData = 6;
        }

        public IMyPlayer ToAsync(IAsyncContext asyncContext)
        {
            return new Async(this, asyncContext);
        }

        public IMyPlayer ToAsync()
        {
            return new Async(this, null);
        }
    }
}
