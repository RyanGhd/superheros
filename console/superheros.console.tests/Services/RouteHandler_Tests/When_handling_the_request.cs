using System.Diagnostics;
using NuGet.Frameworks;
using NUnit.Framework;
using superheors.console.Services;
using superheors.console.Services.Router;

namespace superheros.console.tests.Services.RouteHandler_Tests;

public class When_handling_the_request
{
    [SetUp]
    public void Setup()
    {
        new Bootstrapper().Bootstrap();

    }
    [Test]
    public void Service_should_use_the_first_decision()
    {
        var sut = Bootstrapper.ServiceProvider.GetService(typeof(IRouteHandler));

        if(sut == null)
            Assert.Fail("Sut can't be null");

        (sut as IRouteHandler).Handle("test");

        Assert.Pass("");
    }
}