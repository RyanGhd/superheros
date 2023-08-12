using Autofac;
using Autofac.Builder;
using Autofac.Extensions.DependencyInjection;
using superheros.server;
using superheros.server.Services;
using superheros.server.Services.Queries.SuperheroQueries;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

builder.Host.ConfigureServices(sc => startup.ConfigureServices(sc));

var factory = new AutofacServiceProviderFactory(c => startup.ConfigureContainer(c));
builder.Host.UseServiceProviderFactory(factory);
//builder.Host.ConfigureContainer<ContainerBuilder>(c => startup.ConfigureContainer(c));

var app = builder.Build();

startup.Configure(app,builder.Environment);

var sp = app.Services.GetService(typeof(IGetAllSuperherosQuery));

app.Run();
