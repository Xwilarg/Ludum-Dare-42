using UnityEngine;

public class Weapon
{
    public Weapon(string name, float damage, WeaponType type, float deviation, float fireRate, int shellNb, Sprite sprite, float velocity, float baseY)
    {
        this.name = name;
        this.damage = damage;
        this.type = type;
        this.deviation = deviation;
        this.fireRate = fireRate;
        this.shellNb = shellNb;
        this.sprite = sprite;
        this.velocity = velocity;
        this.baseY = baseY;
    }

    public enum WeaponType
    {
        Raycast,
        Projectile
    }

    public readonly string name;
    public readonly float damage;
    public readonly WeaponType type;
    public readonly float deviation; // / 1
    public readonly float fireRate; // s
    public readonly int shellNb;
    public readonly Sprite sprite;
    public readonly float velocity;
    public readonly float baseY;

    public static Weapon Gun = new Weapon("Gun", 10f, WeaponType.Raycast, .1f, 1, 1, null, float.PositiveInfinity, 0f);

    public static Weapon GrenadeLauncher = new Weapon("Grenade Launcher", 50f, WeaponType.Projectile, .1f, 2, 1, Resources.Load<Sprite>("Projectiles/Grenade"), 10f, .5f);

    public static Weapon[] Weapons = new Weapon[] { Gun };
}