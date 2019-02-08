using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public virtual IPlayer Create(IntPtr playerPointer)
        {
            return new Player(playerPointer);
        }
    }
}