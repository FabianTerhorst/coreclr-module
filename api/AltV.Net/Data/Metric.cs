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

    [Obsolete("Deprecated old behavior, remove in future. Use End2")]
    public void End()
    {
        unsafe
        {
            Core.Library.Server.Metric_End(MetricNativePointer);
        }
    }

    public void Add(ulong value)
    {
        unsafe
        {
            Core.Library.Server.Metric_Add(MetricNativePointer, value);
        }
    }

    public void Inc()
    {
        unsafe
        {
            Core.Library.Server.Metric_Inc(MetricNativePointer);
        }
    }

    public void End2()
    {
        unsafe
        {
            Core.Library.Server.Metric_End2(MetricNativePointer);
        }
    }
}