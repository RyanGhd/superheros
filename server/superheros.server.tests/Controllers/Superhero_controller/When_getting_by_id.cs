using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using superheros.server.Controllers;
using superheros.server.Model;
using superheros.server.Services.Queries.SuperheroQueries;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using superheros.server.tests.Fixtures;

namespace superheros.server.tests.Controllers.Superhero_controller;

[TestFixture]
public class When_getting_by_id
{
    private SuperheroControllerFixture _fixture = new SuperheroControllerFixture();

    [Test]
    public async Task Given_that_the_superhero_with_id_1_exits_when_the_client_queries_by_id_then_the_service_returns_superhero_1()
    {
        //arrange
        var sut = _fixture.Init()
            .WithSuperheroByIdQueryReturnsSuperhero1()
            .Build();


        var traceId = Guid.NewGuid().ToString();


        //act 
        var okResult = await sut.GetAsync(traceId, 1);

        if (okResult.Result == null)
            throw new Exception("OkResult.Result can not be null");

        var objResult = (ObjectResult)okResult.Result;

        //assert
        Assert.IsInstanceOf<Superhero>(objResult.Value);

        var selectedSuperhero = (Superhero)objResult.Value!;

        Assert.AreEqual(selectedSuperhero.Id, 1);
    }
}