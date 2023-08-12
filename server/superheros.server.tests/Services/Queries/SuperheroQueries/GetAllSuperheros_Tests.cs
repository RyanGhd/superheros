using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using superheros.server.Model;
using superheros.server.Services.Platform;
using superheros.server.Services.Queries.SuperheroQueries;

// ReSharper disable All

namespace superheros.server.tests.Services.Queries.SuperheroQueries;

[TestFixture]
public class GetAllSuperheros_Tests
{
    [Test]
    public async Task Given_that_this_the_first_time_loading_the_data_When_loading_the_data_Then_the_service_reads_the_data_from_the_file()
    {
        //arrange
        var loggerMock = new Mock<ILogger<GetAllSuperherosQuery>>();

        var cacheMock = new Mock<ICacheProvider>();
        cacheMock.Setup(x => x.GetAsync<ImmutableList<Superhero>>(It.IsAny<string>())).Returns(Task.FromResult<ImmutableList<Superhero>>(null));

        var sut = new GetAllSuperherosQuery(loggerMock.Object, cacheMock.Object);

        //act
        var result = await sut.GetAsync(Guid.NewGuid().ToString());

        //assert
        Assert.IsNotNull(result);
        Assert.IsNotEmpty(result);
    }

    
}