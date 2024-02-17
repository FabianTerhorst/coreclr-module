using System;

namespace AltV.Net.Elements.Entities;

public interface IMetric
{
    IntPtr MetricNativePointer { get; }
    ICore Core { get; }
    string Name { get; }
    ulong Value { get; set; }
    void Begin();
    [Obsolete("Deprecated old behavior, remove in future. Use End2")]
    void End();
    void Add(ulong value);
    void Inc();
    void End2();
}