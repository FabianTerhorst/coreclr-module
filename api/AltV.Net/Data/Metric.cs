using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Data;

public class Metric : IMetric
{
    public IntPtr MetricNativePointer { get; }
    public ICore Core { get; }

    public Metric(ICore core, IntPtr metricNativePointer)
    {
        MetricNativePointer = metricNativePointer;
        Core = core;
    }

    public string Name
    {
        get
        {
            unsafe
            {
                var size = 0;
                return Core.PtrToStringUtf8AndFree(
                    Core.Library.Server.Metric_GetName(MetricNativePointer, &size), size);
            }
        }
    }

    public ulong Value
    {
        get
        {
            unsafe
            {
                return Core.Library.Server.Metric_GetValue(MetricNativePointer);
            }
        }
        set
        {
            unsafe
            {
                Core.Library.Server.Metric_SetValue(MetricNativePointer, value);
            }
        }
    }

    public void Begin()
    {
        unsafe
        {
            Core.Library.Server.Metric_Begin(MetricNativePointer);
        }
    }

    public void End()
    {
        unsafe
        {
            Core.Library.Server.Metric_End(MetricNativePointer);
        }
    }
}