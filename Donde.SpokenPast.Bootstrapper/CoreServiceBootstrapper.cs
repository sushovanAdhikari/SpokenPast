using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Donde.SpokenPast.Bootstrapper
{
    public class CoreServiceBootstrapper : BaseBootstrapper
    {
        public static void BootstrapCoreService(Container simpleInjectorContainer)
        {
            RegisterInstancesByNamespace(simpleInjectorContainer,
                 new List<Assembly>
                {
                    GetServiceInterfaceAssembly(),
                    GetServiceAssembly()
                },
                new List<string>
                {
                    "Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces",
                    "Donde.SpokenPast.Core.Services.Services",
                });

            //any fluent validators can be registered here.
        }

        protected static Func<Assembly> GetServiceInterfaceAssembly { get; } = () => Assembly.Load("Donde.SpokenPast.Core.Service.Interfaces");
        protected static Func<Assembly> GetServiceAssembly { get; } = () => Assembly.Load("Donde.SpokenPast.Core.Services");
    }
}
