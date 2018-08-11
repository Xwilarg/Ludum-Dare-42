public struct Character
{
    private Character(string name, string description1, string description2, string description3, int weight)
    {
        this.name = name;
        this.description1 = description1;
        this.description2 = description2;
        this.description3 = description3;
        this.weight = weight;
    }

    public readonly string name;
    public readonly string description1, description2, description3;
    public readonly int weight;

    public static Character dummy1 = new Character("Dummy One", "First dummy character", "Nothing to say, it's just a dummy", "No... really", 80);
    public static Character dummy2 = new Character("Dummy Two", "Second dummy character", "Nothing to say, it's just a dummy", "No... really", 105);
    public static Character dummy3 = new Character("Dummy Three", "Third dummy character", "Nothing to say, it's just a dummy", "No... really", 65);

    public static Character[] basicCharacters = new Character[] { dummy1, dummy2, dummy3 };
}
