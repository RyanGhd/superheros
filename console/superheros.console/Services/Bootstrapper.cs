using Autofac;
using superheors.console.Services.Router;
using System.Linq;
using Autofac.Extensions.DependencyInjection;

namespace superheors.console.Services;

public class Bootstrapper
{
    public static IServiceProvider? ServiceProvider { get;private set; }
 

    public void Bootstrap()
    {
        if (Bootstrapper.ServiceProvider != null)
            return;

        var containerBuilder = new ContainerBuilder();

        containerBuilder.RegisterType<RouteToFirstWebsiteDecision>().As<IRouterDecision>().SingleInstance();
        containerBuilder.RegisterType<RouteToSecondWebsiteDecision>().As<IRouterDecision>().SingleInstance();
        containerBuilder.RegisterType<RouteHandler>().As<IRouteHandler>();

        var container = containerBuilder.Build();

        var serviceLocator = new AutofacServiceProvider(container);

        Bootstrapper.ServiceProvider = serviceLocator;
    }
}