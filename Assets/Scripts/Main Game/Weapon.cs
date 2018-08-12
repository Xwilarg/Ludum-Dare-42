public class Weapon
{
    public Weapon(string name, float damage, WeaponType type, float deviation, float fireRate, int shellNb)
    {
        this.name = name;
        this.damage = damage;
        this.type = type;
        this.deviation = deviation;
        this.fireRate = fireRate;
        this.shellNb = shellNb;
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

    public static Weapon Gun = new Weapon("Gun", 10f, WeaponType.Raycast, .1f, 1, 1);

    public static Weapon HeavyMachineGun = new Weapon("Heavy Machinegun", 2f, WeaponType.Raycast, 1f, 0.01f, 1);

    public static Weapon Shotgun = new Weapon("Shotgun", 2f, WeaponType.Raycast, .8f, 1.5f, 20);

    public static Weapon[] Weapons = new Weapon[] { Gun };
}