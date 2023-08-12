using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using superheros.server.Services.Queries.SuperheroQueries;

// ReSharper disable All

namespace superheros.server.tests.Services.Queries.SuperheroQueries;

[TestFixture]
public class GetAllSuperheros_Tests
{
    [Test]
    public async Task Service_should_get_all_the_available_superheros_from_the_file()
    {
        //arrange
        var loggerMock = new Mock<ILogger<GetAllSuperheros>>();

        var sut = new GetAllSuperheros(loggerMock.Object);

        //act
        var result = await sut.GetAsync(Guid.NewGuid().ToString());

        //assert
        Assert.IsNotNull(result);
        Assert.IsNotEmpty(result);
    }
}