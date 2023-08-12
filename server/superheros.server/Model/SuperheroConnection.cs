namespace superheros.server.Model;

public class SuperheroConnection
{
    // used for object mapping 
    // ReSharper disable once UnusedMember.Local
    private SuperheroConnection()
    {

    }

    public SuperheroConnection(string? groupAffiliation, string? relatives)
    {
        GroupAffiliation = groupAffiliation;
        Relatives = relatives;
    }

    public string? GroupAffiliation { get; private set; }
    public string? Relatives { get; private set; }
}