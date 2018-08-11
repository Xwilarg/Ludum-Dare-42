using UnityEngine;

public struct Character
{
    private Character(string name, string description1,
        float weight, int height, int age, string entryLine, string exitLine, string[] lines,
        RuntimeAnimatorController hanging, Sprite sitDown)
    {
        this.name = name;
        this.description1 = description1;
        this.weight = weight * WeightMultiplicator;
        this.height = height;
        this.age = age;
        this.entryLine = entryLine;
        this.exitLine = exitLine;
        this.lines = lines;
        this.hanging = hanging;
        this.sitDown = sitDown;
    }

    public readonly string name;
    public readonly string description1;
    public readonly float weight;
    public readonly int height;
    public readonly int age;
    public readonly string entryLine;
    public readonly string exitLine;
    public readonly string[] lines;
    public readonly RuntimeAnimatorController hanging;
    public readonly Sprite sitDown;

    public const float WeightMultiplicator = 0.33f;

    public static Character tsundere = new Character("Hanashi Tsubaka",
        "Your childhood friend that definitly doesn't like you, you idiot!\nShe got rejected many times at medium school so she now is afraid to confess.",
        55f, 167, 21,
        "Oh, it's you... I mean, you're late!",
        "If you think I'm a burden...",
        new string[] {
            "It's not like I wanted to be save or anything, stupid!",
            "I'm just hooking on you that hard because I don't want to fall, okay ?!",
            "When we will be out of this, I want a cup of tea.",
            "You... won't throw me away, will you ?",
            "You really run fast, that remind me when we were at primary school..."
        }, Resources.Load<RuntimeAnimatorController>("Tsundere/HangingState"), Resources.Load<Sprite>("Tsundere/SitDown"));
    public static Character[] basicCharacters = new Character[] { tsundere };
}
