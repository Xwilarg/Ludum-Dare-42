public struct Character
{
    private Character(string name, string description1, string description2, string description3, int weight, string entryLine, string exitLine, string[] lines)
    {
        this.name = name;
        this.description1 = description1;
        this.description2 = description2;
        this.description3 = description3;
        this.weight = weight;
        this.entryLine = entryLine;
        this.exitLine = exitLine;
        this.lines = lines;
    }

    public readonly string name;
    public readonly string description1, description2, description3;
    public readonly int weight;
    public readonly string entryLine;
    public readonly string exitLine;
    public readonly string[] lines;

    public static Character dummy1 = new Character("Tanya Dezora", "Your little sister.... Wait, what is she doing here ?", "", "", 55,
        "Oh, big brother! Nice to see you!", "Eh ? Don't leave me..",
        new string[] {
            "I wonder if mom and dad are okay...",
            "Are we soon arrived ?",
            "I feel safe as long I'm with you, brother"
        });
    public static Character dummy2 = new Character("Father Rohn", "A priest at the church, will do his best to guide you to do right path.", "", "", 95,
        "I will guide you my child.", "I forgive you.",
        new string[] {
            "God forgive you for all these people your threw away.",
            "God will guide us through this disaster.",
            "I will pray for you, my child"
        });
    public static Character dummy3 = new Character("Rikka Leron", "A really energic high school girl... Maybe a bit too much.", "", "", 85,
        "Yeah, free ride!", "I'm flying!",
        new string[] {
            "Faster! Faster!",
            "Just throw me away if you're tired of me, okay ? I'm used to it.",
            "The wind in my hair feel great!"
        });

    public static Character[] basicCharacters = new Character[] { dummy1, dummy2, dummy3 };
}
