using System;
using System.Collections.Generic;

public class Item
{
    public string Name { get; set; }

    public virtual void Use(Player player) { }

    public override string ToString()
    {
        return Name;
    }
}

public class HealthPotion : Item
{
    public HealthPotion()
    {
        Name = "Лечебное зелье";
    }

    public override void Use(Player player)
    {
        player.HP = 100;
        Console.WriteLine("Здоровье восстановлено!");
    }
}

public class Weapon : Item
{
    public int Damage { get; set; }
    public int Attack { get; set; }

    public Weapon(string name, int damage, int attack)
    {
        Name = name;
        Damage = damage;
        Attack = attack;
    }

    public override void Use(Player player)
    {
        player.CurrentWeapon = this;
    }

    public override string ToString()
    {
        return $"{Name} (Урон: {Damage}, Атака: {Attack})";
    }
}

public class Armor : Item
{
    public int Defense { get; set; }

    public Armor(string name, int defense, int protection)
    {
        Name = name;
        Defense = defense;
    }

    public override void Use(Player player)
    {
        player.CurrentArmor = this;
    }

    public override string ToString()
    {
        return $"{Name} (Защита: {Defense})";
    }
}

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
        CurrentWeapon = new Weapon("Кулаки", 5, 5);
        CurrentArmor = new Armor("Одежда", 2, 2);
    }

    public bool TryDodge()
    {
        Random random = new Random();
        return random.Next(100) < 40;
    }

    public int CalculateBlockedDamage(int damage)
    {
        Random random = new Random();
        double blockPercent = random.Next(70, 101) / 100.0;
        return Math.Max(0, damage - (int)(Defense * blockPercent));
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    public string GetStatus()
    {
        return $"Здоровье: {HP}";
    }

    public string GetEquipment()
    {
        return $"Оружие: {CurrentWeapon?.Name}, Броня: {CurrentArmor?.Name}";
    }
}

