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

