namespace superheros.server.Model;

public class Biography
{
    // used for object mapping 
    // ReSharper disable once UnusedMember.Local
    private Biography()
    {

    }
    public Biography(string fullName, string alterEgos, List<string> aliases, string placeOfBirth, string firstAppearance, string publisher, string alignment)
    {
        FullName = fullName;
        AlterEgos = alterEgos;
        Aliases = aliases;
        PlaceOfBirth = placeOfBirth;
        FirstAppearance = firstAppearance;
        Publisher = publisher;
        Alignment = alignment;
    }

    public string FullName { get;private set; }
    public string AlterEgos { get; private set; }
    public List<string> Aliases { get; private set; }
    public string PlaceOfBirth { get; private set; }
    public string FirstAppearance { get; private set; }
    public string Publisher { get; private set; }
    public string Alignment { get; private set; }
}