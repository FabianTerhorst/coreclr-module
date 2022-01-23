using System;

namespace AltV.Net.Interactions;

public class InteractionsServiceBuilder
{
    private InteractionsServiceOptions serviceOptions;

    public InteractionsServiceBuilder(InteractionsServiceOptions serviceOptions)
    {
        this.serviceOptions = serviceOptions;
    }

    public void AddGlobalThreadMapping(Func<ulong, ulong, ulong> mapping)
    {
        serviceOptions.GlobalThreadMapping = mapping;
    }

    public void AddThreadForType(params ulong[] types)
    {
        AddThreadForType(null, types);
    }
    
    public void AddThreadForType(Grid grid, params ulong[] types)
    {
        for (int i = 0, length = types.Length; i < length; i++)
        {
            serviceOptions.Types.Add(types[i]);
        }
        serviceOptions.Threads.Add((types, grid ?? BuildDefaultGrid()));
    }
    
    public void AddThread(Grid grid = null)
    {
        serviceOptions.Threads.Add((null, grid ?? BuildDefaultGrid()));
    }

    public void AddType(ulong type)
    {
        serviceOptions.Types.Add(type);
    }

    private static Grid BuildDefaultGrid()
    {
        return new Grid(50_000, 50_000, 100, 10_000, 10_000);
    }

    public InteractionsService Build()
    {
        return new InteractionsService(serviceOptions.Types, serviceOptions.Threads, serviceOptions.GlobalThreadMapping);
    }
}