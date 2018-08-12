public class Weapon
{
    public Weapon(string name, float damage, WeaponType type, float deviation, int fireRate, int shellNb)
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
    public readonly float deviation; // degrees
    public readonly int fireRate; // ms
    public readonly int shellNb;

    public static Weapon Gun = new Weapon("Gun", 10f, WeaponType.Raycast, 10, 1000, 1);

    public static Weapon HeavyMachineGun = new Weapon("Heavy Machinegun", 2f, WeaponType.Raycast, 30, 10, 1);

    public static Weapon Shotgun = new Weapon("Shotgun", 2f, WeaponType.Raycast, 20, 1500, 20);

    public static Weapon[] Weapons = new Weapon[] { Gun, HeavyMachineGun, Shotgun };
}