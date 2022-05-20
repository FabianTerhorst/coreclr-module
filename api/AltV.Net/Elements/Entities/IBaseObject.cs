using System;
using System.Collections.Generic;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Types;

namespace AltV.Net.Elements.Entities
{
    public interface IBaseObject : ISharedBaseObject
    {
        new ICore Core { get; }
    }
}