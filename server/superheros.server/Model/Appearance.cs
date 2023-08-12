namespace superheros.server.Model;

public class Appearance
{
    // used for object mapping 
    // ReSharper disable once UnusedMember.Local
    private Appearance()
    {
        
    }
    public Appearance(string? gender, string? race, List<string>? height, List<string>? weight, string? eyeColor, string? hairColor)
    {
        Gender = gender;
        Race = race;
        Height = height;
        Weight = weight;
        EyeColor = eyeColor;
        HairColor = hairColor;
    }

    public string? Gender { get;private set; }
    public string? Race { get; private set; }
    public List<string>? Height { get; private set; }
    public List<string>? Weight { get; private set; }
    public string? EyeColor { get; private set; }
    public string? HairColor { get; private set; }
}