public struct Character
{
    private Character(string name, string description, int weight)
    {
        this.name = name;
        this.description = description;
        this.weight = weight;
    }

    private readonly string name;
    private readonly string description;
    private readonly int weight;

    public static Character dummy1 = new Character("Dummy One", "First dummy character", 80);
    public static Character dummy2 = new Character("Dummy Two", "Second dummy character", 105);
    public static Character dummy3 = new Character("Dummy Three", "Third dummy character", 65);

    public static Character[] basicCharacters = new Character[] { dummy1, dummy2, dummy3 };
}
