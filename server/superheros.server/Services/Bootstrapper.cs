using Autofac;
using Autofac.Extensions.DependencyInjection;
using superheros.server.Services.Queries.SuperheroQueries;

namespace superheros.server.Services;

public class Bootstrapper
{
    public void Bootstrap(IServiceCollection serviceCollection)
    {
        

        var cb = new ContainerBuilder();

        cb.Populate(serviceCollection);

        //register
        

        //build
        var container = cb.Build();

        var sp = new AutofacServiceProvider(container);

        SuperheroServiceProvider.Instance = sp;
    }
}