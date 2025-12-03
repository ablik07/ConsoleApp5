public class HealthPotion : Item
{
    public HealthPotion() => Name = "Лечебное зелье";

    public override void Use(Player player)
    {
        player.HP = 100;
        Console.WriteLine("Здоровье восстановлено!");
    }
}