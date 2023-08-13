using System;
using System.Collections.Generic;

namespace superheros.server.Model;

public class Superhero
{
    public Superhero(int id, string? name, string? slug, Powerstats? powerStats, Appearance? appearance, Biography? biography, Work? work, SuperheroConnection? connections, Images? images)
    {
        Id = id;
        Name = name;
        Slug = slug;
        PowerStats = powerStats;
        Appearance = appearance;
        Biography = biography;
        Work = work;
        Connections = connections;
        Images = images;
    }

    public int Id { get; private set; }
    public string? Name { get; private set; }
    public string? Slug { get; private set; }
    public Powerstats? PowerStats { get; private set; }
    public Appearance? Appearance { get; private set; }
    public Biography? Biography { get; private set; }
    public Work? Work { get; private set; }
    public SuperheroConnection? Connections { get; private set; }
    public Images? Images { get; private set; }
}