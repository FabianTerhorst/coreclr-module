using System;
using System.Collections.Generic;

namespace AltV.Net.Interactions;

public class InteractionsServiceOptions
{
    public HashSet<ulong> Types { get; }
    
    public Func<ulong, ulong, ulong> GlobalThreadMapping { get; set; }

    public List<(ulong[], Grid)> Threads { get; }

    public InteractionsServiceOptions()
    {
        Types = new HashSet<ulong>();
        GlobalThreadMapping = null;
        Threads = new List<(ulong[], Grid)>();
    }
}