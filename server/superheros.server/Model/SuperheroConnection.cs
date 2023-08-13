namespace superheros.server.Model;

public class SuperheroConnection
{
    public SuperheroConnection(string? groupAffiliation, string? relatives)
    {
        GroupAffiliation = groupAffiliation;
        Relatives = relatives;
    }

    public string? GroupAffiliation { get; private set; }
    public string? Relatives { get; private set; }
}