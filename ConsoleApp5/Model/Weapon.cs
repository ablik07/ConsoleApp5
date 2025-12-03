public class Weapon : Item
{
    public int Attack { get; set; }

    public Weapon(string name, int attack)
    {
        Name = name;
        Attack = attack;
    }

    public override void Use(Player player) => player.CurrentWeapon = this;

    public override string ToString() => $"{Name} (Атака: {Attack})";
}