public class Armor : Item
{
    public int Defense { get; set; }

    public Armor(string name, int defense)
    {
        Name = name;
        Defense = defense;
    }

    public override void Use(Player player) => player.CurrentArmor = this;

    public override string ToString() => $"{Name} (Защита: {Defense})";
}