using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Dependencies;
using BreezeExperimenting.Models;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace BreezeExperimenting
{
    public static class IocConfig
    {
        public static void Register()
        {
            #region Config
            // Create the container as usual.
            var container = new Container();

            var services = GlobalConfiguration.Configuration.Services;
            var controllerTypes = services.GetHttpControllerTypeResolver()
                .GetControllerTypes(services.GetAssembliesResolver());

            // register Web API controllers (important! http://bit.ly/1aMbBW0)
            foreach (var controllerType in controllerTypes)
            {
                container.Register(controllerType);
            }
            #endregion

            var perRequestLifeTime = new WebRequestLifestyle();


            container.Register<BreezeRepository>(perRequestLifeTime);
            container.Register<BreezeContextProvider>(perRequestLifeTime);


            // Verify the container configuration
            container.Verify();

            // Register the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        public class SimpleInjectorWebApiDependencyResolver : IDependencyResolver
        {
            private readonly Container _container;

            public SimpleInjectorWebApiDependencyResolver(
                Container container)
            {
                _container = container;
            }

            [DebuggerStepThrough]
            public IDependencyScope BeginScope()
            {
                return this;
            }

            [DebuggerStepThrough]
            public object GetService(Type serviceType)
            {
                return ((IServiceProvider)_container)
                    .GetService(serviceType);
            }

            [DebuggerStepThrough]
            public IEnumerable<object> GetServices(Type serviceType)
            {
                return _container.GetAllInstances(serviceType);
            }

            [DebuggerStepThrough]
            public void Dispose()
            {
            }
        }
    }
}