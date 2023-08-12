// ReSharper disable All

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using superheros.server.Controllers;
using superheros.server.Services.Queries.SuperheroQueries;

namespace superheros.server.tests.Controllers.Superhero_controller;

[TestFixture]
public class When_getting
{
    [Test]
    public async Task Given_there_is_no_superheros_then_the_service_returns_an_empty_list()
    {
        //arrange
        var loggerMock = new Mock<ILogger<SuperheroController>>();
        var getAllSuperherosMock = new Mock<GetAllSuperheros>();
        
        var sut = new SuperheroController(loggerMock.Object, getAllSuperherosMock.Object);

        //act 
        var result = await sut.GetAsync();

        //assert
        Assert.IsNotNull(result.Value);

#pragma warning disable CS8604
        Assert.IsEmpty(result.Value);
#pragma warning restore CS8604
    }
}