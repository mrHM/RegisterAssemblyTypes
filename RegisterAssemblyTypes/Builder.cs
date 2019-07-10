using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace RegisterAssemblyTypes
{
    public static class Builder
    {
        public static void RegisterAssemblyTypes(IServiceCollection services, Assembly assembly, string typeToRegister, ServiceLifetime lifetime)
        {
            if (assembly == null || assembly.GetTypes().Length == 0)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            if (String.IsNullOrEmpty(typeToRegister))
            {
                throw new ArgumentNullException(typeToRegister);
            }
            var assemblies = assembly.GetTypes().Where(c => c.Name.EndsWith(typeToRegister) && c.IsClass);
            //var interfaces=
            foreach (var type in assemblies)
            {
                foreach (var interfaces in type.GetInterfaces())
                {
                    services.Add(new ServiceDescriptor(interfaces, type, lifetime));
                }
            }
        }
    }
}
