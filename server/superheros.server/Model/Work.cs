namespace superheros.server.Model;

public class Work
{
    // used for object mapping 
    // ReSharper disable once UnusedMember.Local
    private Work()
    {

    }

    public Work(string? occupation, string? @base)
    {
        Occupation = occupation;
        Base = @base;
    }

    public string? Occupation { get;private set; }
    public string? Base { get; private set; }
}