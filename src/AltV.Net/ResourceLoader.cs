using System;
using System.Linq;
using System.Reflection;

namespace AltV.Net
{
    internal class ResourceLoader
    {
        private readonly IResource[] resources;

        public ResourceLoader()
        {
            resources = Assembly.GetAssembly(typeof(IResource))
                .GetTypes()
                .Where(myType =>
                    myType.IsClass && !myType.IsAbstract && myType.GetInterfaces().Contains(typeof(IResource)))
                .Select(type =>
                {
                    var resource = (IResource) Activator.CreateInstance(type);
                    return resource;
                })
                .ToArray();
        }

        public void Start()
        {
            foreach (var resource in resources)
            {
                resource.OnStart();
            }
        }

        public void Stop()
        {
            foreach (var resource in resources)
            {
                resource.OnStop();
            }
        }
    }
}