using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace superheros.console.Services;

public class Bootstrapper
{
    public static IServiceProvider? ServiceProvider { get;private set; }
 

    public void Bootstrap()
    {
        if (Bootstrapper.ServiceProvider != null)
            return;

    
        var builder= new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var config = builder.Build();
    
        var containerBuilder = new ContainerBuilder();

        containerBuilder.RegisterInstance(config).As<IConfiguration>().SingleInstance();

        var container = containerBuilder.Build();

        var serviceLocator = new AutofacServiceProvider(container);

        Bootstrapper.ServiceProvider = serviceLocator;
    }
}