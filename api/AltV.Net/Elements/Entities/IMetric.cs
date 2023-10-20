using System;

namespace AltV.Net.Elements.Entities;

public interface IMetric
{
    IntPtr MetricNativePointer { get; }
    ICore Core { get; }
    string Name { get; }
    ulong Value { get; set; }
    void Begin();
    void End();
}