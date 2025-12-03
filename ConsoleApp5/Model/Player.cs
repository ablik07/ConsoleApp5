using System;

public class Player
{
    public int HP { get; set; }
    public bool IsFrozen { get; set; }
    public Weapon CurrentWeapon { get; set; }
    public Armor CurrentArmor { get; set; }

    public int Attack => CurrentWeapon?.Attack ?? 5;
    public int Defense => CurrentArmor?.Defense ?? 2;

    public Player(int hp)
    {
        HP = hp;
        CurrentWeapon = new Weapon("Кулаки", 5);
        CurrentArmor = new Armor("Одежда", 2);
    }

    public bool TryDodge() => RandomClass.PercentChance(40);

    public int CalculateBlockedDamage(int damage)
    {
        double blockPercent = RandomClass.Next(70, 101) / 100.0;
        return Math.Max(0, damage - (int)(Defense * blockPercent));
    }

    public void TakeDamage(int damage) => HP -= damage;

    public string GetStatus() => $"Здоровье: {HP}";

    public string GetEquipment() => $"Оружие: {CurrentWeapon?.Name}, Броня: {CurrentArmor?.Name}";
}