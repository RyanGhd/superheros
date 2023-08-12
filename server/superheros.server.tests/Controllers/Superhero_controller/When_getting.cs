// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using superheros.server.Controllers;
using superheros.server.Model;
using superheros.server.Services.Queries.SuperheroQueries;

namespace superheros.server.tests.Controllers.Superhero_controller;

[TestFixture]
public class When_getting
{
    [Test]
    public async Task Given_there_is_no_superheros_then_the_service_returns_an_empty_list()
    {
        //arrange
        var loggerMock = new Mock<ILogger<SuperherosController>>();
        var getAllSuperherosMock = new Mock<IGetAllSuperheros>();
        getAllSuperherosMock.Setup(x => x.GetAsync()).Returns(Task.FromResult(new List<Superhero>() as IList<Superhero>));

        var sut = new SuperherosController(loggerMock.Object, getAllSuperherosMock.Object);

        //act 
        var okResult = await sut.GetAsync();

        if (okResult.Result == null)
            throw new Exception("OkResult.Result can not be null");

        var objResult = (ObjectResult)okResult.Result;

        //assert
        Assert.IsInstanceOf<IList<Superhero>>(objResult.Value);

        var superheros = objResult.Value as IList<Superhero>;

        Assert.IsNotNull(superheros);

        Assert.AreEqual(superheros?.Count,0);
    }
}