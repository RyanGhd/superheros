using Microsoft.Extensions.Logging;
using Moq;
using superheros.server.Controllers;
using superheros.server.Model;
using superheros.server.Services.Queries.SuperheroQueries;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace superheros.server.tests.Fixtures;

public class SuperheroControllerFixture
{
    private Mock<ILogger<SuperherosV1Controller>> _loggerMock;
    private Mock<IGetAllSuperherosQuery> _getAllSuperherosMock;
    private Mock<IGetSuperheroByIdQuery> _getSuperheroByIdQueryMock;

    public SuperheroControllerFixture Init()
    {
        _loggerMock = new Mock<ILogger<SuperherosV1Controller>>();

        _getAllSuperherosMock = new Mock<IGetAllSuperherosQuery>();
       
        _getSuperheroByIdQueryMock = new Mock<IGetSuperheroByIdQuery>();

        return this;

    }

    public SuperheroControllerFixture WithAllSuperherosQueryReturnsList(List<Superhero> result)
    {
        _getAllSuperherosMock.Setup(x => x.GetAsync(It.IsAny<string>()))
            .Returns(Task.FromResult(result as IList<Superhero>));

        return this;
    }

    public SuperheroControllerFixture WithSuperheroByIdQueryReturnsSuperhero1()
    {
        var superhero1 = this.LoadSuperhero1();

        _getSuperheroByIdQueryMock.Setup(x => x.GetAsync(1,It.IsAny<string>()))
            .Returns(Task.FromResult(superhero1)!);
     

        return this;
    }

    public SuperherosV1Controller Build()
    {
        var instance = new SuperherosV1Controller(_loggerMock.Object, _getAllSuperherosMock.Object,
            _getSuperheroByIdQueryMock.Object);
        
        return instance;
    }

    public Superhero LoadSuperhero1()
    {
        var content = File.ReadAllText(Path.Combine("Data", "superhero1.json"));
        var data = JsonConvert.DeserializeObject<Superhero>(content);
        return data;
    }
}