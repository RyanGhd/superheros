using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace superheros.console;

public class Bootstrapper
{
    public static IServiceProvider? ServiceProvider { get; private set; }


    public void Bootstrap()
    {
        if (ServiceProvider != null)
            return;

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var config = builder.Build();

        var containerBuilder = new ContainerBuilder();

        containerBuilder.RegisterInstance(config).As<IConfiguration>().SingleInstance();

        var container = containerBuilder.Build();

        var serviceLocator = new AutofacServiceProvider(container);

        ServiceProvider = serviceLocator;
    }

    //public async Task<string> GetData()
    //{
    //    var http = new HttpClient();

    //    var message = new HttpRequestMessage(HttpMethod.Post, "https://google.com");

    //    message.Content = new StringContent("test");
        
    //    string content = string.Empty;

    //    using (var response = await http.SendAsync(message))
    //    {
    //        if (response.IsSuccessStatusCode)
    //        {
    //            content = await response.Content.ReadAsStringAsync();
    //        }
    //    }

    //    return content;
    //}
}