using Autofac;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using superheros.server.Services.Platform;
using superheros.server.Services.Queries.SuperheroQueries;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace superheros.server;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This is the default if you don't have an environment specific method.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication();
        services.AddAuthorization();
        services.AddControllers();
        services.AddEndpointsApiExplorer(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddSwaggerGen();
    }

    // This is the default if you don't have an environment specific method.
    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterType<GetAllSuperherosQuery>().As<IGetAllSuperherosQuery>().SingleInstance();
        builder.RegisterType<GetSuperheroByIdQuery>().As<IGetSuperheroByIdQuery>().SingleInstance();
        
        builder.RegisterType<CacheProvider>().As<ICacheProvider>().SingleInstance();
        builder.RegisterType<MemoryCache>().As<IMemoryCache>().SingleInstance();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseStaticFiles();
    }

     
}