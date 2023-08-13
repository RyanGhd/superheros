using Autofac;
using Autofac.Builder;
using Autofac.Extensions.DependencyInjection;
using NLog;
using NLog.Web;
using superheros.server;
using superheros.server.Services;
using superheros.server.Services.Queries.SuperheroQueries;
using System;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    var startup = new Startup(builder.Configuration);

    builder.Host.ConfigureServices(sc => startup.ConfigureServices(sc));

    var factory = new AutofacServiceProviderFactory(c => startup.ConfigureContainer(c));
    builder.Host.UseServiceProviderFactory(factory);

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    startup.Configure(app,builder.Environment);

    var sp = app.Services.GetService(typeof(IGetAllSuperherosQuery));

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
