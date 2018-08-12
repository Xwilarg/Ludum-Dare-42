using System.Collections.Generic;
using UnityEngine;

public class Character
{
    private Character(string name, string description1,
        float weight, int height, int age, string entryLine, string exitLine, string[] lines,
        RuntimeAnimatorController hanging, Sprite sitDown, Sexe sexe, string winAlone)
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
        nbSpecials = 0;
        this.sexe = sexe;
        this.winAlone = winAlone;
    }

    public enum Sexe
    {
        Male,
        Female
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
    public int nbSpecials;
    public Sexe sexe;
    public string winAlone;

    public const float WeightMultiplicator = 0.33f;

    public static Character clone = new Character("Clone",
        "Your childhood friend that definitly doesn't like you, you idiot!\nShe got rejected many times at medium school so she now is afraid to confess.",
        80f, 175, 23,
        "At your order.",
        "Fighting for you was an honor.",
        new string[] {
            "Enemies don't stand a chance.",
            "Aiming at target.",
            "For the earth!"
        }, Resources.Load<RuntimeAnimatorController>("Clone/HangingState"), Resources.Load<Sprite>("Clone/SitDown"), Sexe.Female,
        "");

    public static Character tsundere = new Character("Hanashi Tsubaka",
        "Your childhood friend that definitly doesn't like you, you idiot!\nShe got rejected many times at medium school so she now is afraid to confess.",
        55f, 167, 21, // IMC: 19.7
        "Oh, it's you... I mean, you're late!",
        "If you think I'm a burden...",
        new string[] {
            "It's not like I wanted to be save or anything, stupid!",
            "I'm just hooking on you that hard because I don't want to fall, okay ?!",
            "When we will be out of this, I want a cup of tea.",
            "You... won't throw me away, will you ?",
            "You really run fast, that remind me when we were at primary school ..."
        }, Resources.Load<RuntimeAnimatorController>("Tsundere/HangingState"), Resources.Load<Sprite>("Tsundere/SitDown"), Sexe.Female,
        "You ended up alone with your childhood tsundere friend, Hanashi Tsubaka. You didn't manage to create a new world but at least you could now die peacefully as she confessed to you.");

    public static Character drunkMan = new Character("Jhon Joe Jimbob",
        "Lost his parents at age 14 and found resilience in alcohol, will probably lose his life too now, that’s sad, but he is fat, so it’s funny.",
        84f, 178, 37, // IMC: 26.5
        "Damn, it sWaYs!",
        "Leave me here, I'll throw up.",
        new string[] {
            "A little drink milady ?",
            "Hooo gangster, holds up!",
            "Hello cutie, wanna see my giant beast ? ^^",
            "I think he’s following us, not sure, I might be stoned too.",
            "You know, I always thought that my left toe was bigger than my right one hehe."
        }, Resources.Load<RuntimeAnimatorController>("DrunkMan/HangingState"), Resources.Load<Sprite>("DrunkMan/SitDown"), Sexe.Male,
        "");

    public static Character fearful = new Character("Edmund Derp",
        "Is afraid of strange-shaped clouds, likes watch TV with his pet-hamster.",
        58f, 169, 21, // IMC: 20.3
        "WHERE ARE WE !?",
        "WHY, WHY DOES EVERYONE LET’S ME DOWN !!!??!",
        new string[]
        {
            "I think I saw a spider !!?!",
            "Am I going to die ?! No, No, I don’t want to ...",
            "AAAAAAAAAAAAAAAAAAAAAAH, oh, it’s a photon, nevermind.",
            "I LOST MY PHONE !!",
            "*glares at infinite endless space around, anxious*",
        }, Resources.Load<RuntimeAnimatorController>("Fearful/HangingState"), Resources.Load<Sprite>("Fearful/SitDown"), Sexe.Male,
        "");

    public static Character LittleSister = new Character("Tanya Dezora",
        "Your little sister. Wait… What is she doing here ?",
        24f, 110, 6, // IMC: 19.8
        "Oh, big brother! Nice to see you!",
        "No no no, don’t leave me!",
        new string[]
        {
            "I wonder if mom and dad are okay...",
            "Are we soon arrived ?",
            "I feel safe as long I’m with you!",
            "I think I peed myself...",
            "What is this big scary thing behind ?",
        }, Resources.Load<RuntimeAnimatorController>("LittleSister/HangingState"), Resources.Load<Sprite>("LittleSister/SitDown"), Sexe.Female,
        "");

    public static Character SportGirl = new Character("Rikka Naru",
        "When she was young, Rikka was always sick and stick to bed. Now that she can run around, well, she run around.",
        63f, 173, 17, // IMC: 21
        "Yeah! Free ride!",
        "I’m flying!",
        new string[]
        {
            "Faster! Faster!",
            "The wind in my hair feels great!",
            "Wooho!!",
            "What is this thing behind ? Does it want to fight ?",
            "Next time, you go on my shoulders!",
        }, Resources.Load<RuntimeAnimatorController>("SportGirl/HangingState"), Resources.Load<Sprite>("SportGirl/SitDown"), Sexe.Female,
        "");

    public static Character Narcissistic = new Character("Sheldon Tonnelier",
        "Geek, gifted, have a paladin lvl 110 on World of Derpass.",
        62f, 181, 38, // IMC: 18.9
        "Huh, I could’ve done it myself insect.",
        "I’m not falling to my death, I’m studying gravity until death.",
        new string[]
        {
            "Brozingo !",
            "Scissors cuts paper, paper cuts finger, there is blood, help me !",
            "Can someone cry of stupidity ? Can he understand that he is stupid ?",
            "You suffer ? Does it affect me ? No ? Then suffer in silence.",
            "A single use of Healing Symbol would save us all, but … hm, yes that’s complicated.",
        }, Resources.Load<RuntimeAnimatorController>("Narcissistic/HangingState"), Resources.Load<Sprite>("Narcissistic/SitDown"), Sexe.Male,
        "");

    public static Character DeadBody = new Character("Ded",
        "Judging by the odor and his eye that rolled away, this person looks dead",
        86f, 179, 653, // IMC: 26.8
        "*Oops, he lost an arm*",
        "*poof*",
        new string[]
        {
            "...",
            "*Looks dead*",
            "*Oh his eye moved! Nevermind, just a worm*",
            "...",
            "...",
        }, Resources.Load<RuntimeAnimatorController>("DeadBody/HangingState"), Resources.Load<Sprite>("DeadBody/SitDown"), Sexe.Male,
        "");

    public static Character Medic = new Character("Albrecht Ludwing",
        "Does not care about life, but will never run out of syringes. Who needs a heart anyway ? You ? Ahahahahah ... No.",
        79f, 192, 43, // IMC: 21.4
        "Oktoberfest !",
        "Auf wiedersehen... dummkopf!",
        new string[]
        {
            "Hello fräuleins!",
            "Headache ? Sad.",
            "Oops! That was not medicine!",
            "Medic here, Medic there, can’t you stop crying, you just lost a leg ...",
            "You know, that’s not really good for your back.",
        }, Resources.Load<RuntimeAnimatorController>("Medic/HangingState"), Resources.Load<Sprite>("Medic/SitDown"), Sexe.Male,
        "");

    public static Character Epichan = new Character("Epi-chan",
        "Know a good school you should probably join for only *cough* 8000€ by years",
        65f, 168, 18, // IMC: 23
        "Oh, hi, I know a very good school you should try, we have a very interesting pedagogy and it’s not that expensive you know.",
        "Ah, wait, you can pay in 8 times!",
        new string[]
        {
            "You should try to go to an open day, just to see how it is ...",
            "The most important is to never give up you know ?",
            "You need help with something ? ... Just look on the internet or man google.",
            "If you don’t have enough money, you can also borrow some to banks. The we will be glad to borrow yours.",
            "So you will join our school ? At least do it for me, please.",
        }, Resources.Load<RuntimeAnimatorController>("Epichan/HangingState"), Resources.Load<Sprite>("Epichan/SitDown"), Sexe.Female,
        "");

    public static Character ConfusedGuy = new Character("Dimitry Delabar",
        "Always have his head on the clouds, he lost countless jobs because of that.",
        79f, 180, 34, // IMC: 24.4
        "Hello there.",
        "Oh, staaars! Everywhere ...",
        new string[]
        {
            "What is this big dog-looking thing behind ?",
            "Can you go a little slower ? It make me a little dizzy",
            "Oh, stop a bit, I saw a beautiful mushroom",
            "Can we take a break ? I need to pee",
            "Isn’t the weather lovely today ?",
        }, Resources.Load<RuntimeAnimatorController>("ConfusedGuy/HangingState"), Resources.Load<Sprite>("ConfusedGuy/SitDown"), Sexe.Male,
        "");

    public static Character Mechanic = new Character("Raoul Dozzo",
        "Loves cars and custom handmade stuff.",
        117f, 174, 34, // IMC: 38.6
        "Hehe, how’s it going lads ?",
        "You lil *?#*+£$",
        new string[]
        {
            "*whistles* hey lady, wanna ride ?",
            "Are we there yet ? I’m getting thirsty hehehe.",
            "Imagine if we had a car, or two cars, two cars sounds better.",
            "I once made her start with the finger if you know what I mean.",
            "Smells like piss",
        }, Resources.Load<RuntimeAnimatorController>("Mechanic/HangingState"), Resources.Load<Sprite>("Mechanic/SitDown"), Sexe.Male,
        "");

    public static Character LostChild = new Character("Aruna Way",
        "Beaten up by her parents for a long time. So ran away from home, only one of her family that is still alive.",
        38f, 144, 11, // IMC: 17.4
        "You … you are not a bad guy ?",
        "I thought we were friends … :’(",
        new string[]
        {
            "Where do you live ?",
            "You have someone to live for ?",
            "My dad used to have a thing like this too, not great memories of it tho.",
            "Could I stay with you after that ?",
            "I don’t know how to thank you ...",
        }, Resources.Load<RuntimeAnimatorController>("LostChild/HangingState"), Resources.Load<Sprite>("LostChild/SitDown"), Sexe.Female,
        "");

    public static Character Vocaloid = new Character("Pina",
        "Vocaloid singer since she was born, she know nothing else than music.",
        0f, 176, 16,
        "Hey it's me, Pina!",
        "Holograms can't die",
        new string[]
        {
            "Did you see Matsuri ?",
            "What is happening ? Nobody makes sence around here",
            "Someone once told me vocaloid are lame, what do you think of it ?",
            "You threw a lot of people away… I’m kind of glad you’re evil too.",
            "I sometimes feel like I’m lifeless but that doesn’t really bother me",
        }, Resources.Load<RuntimeAnimatorController>("Vocaloid/HangingState"), Resources.Load<Sprite>("Vocaloid/SitDown"), Sexe.Female,
        "");

    public static List<Character> basicCharacters = new List<Character>() {
        tsundere, drunkMan, fearful, LittleSister, SportGirl
    };
}
