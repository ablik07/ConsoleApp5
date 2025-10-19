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

public class Enemy
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public bool IgnoreDefense { get; set; }
    public bool IsAlive => HP > 0;

    protected Random random = new Random();

    public virtual int CalculateDamage(Player player)
    {
        return Attack;
    }

    public virtual bool TryFreezePlayer()
    {
        return false;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    public string GetStatus()
    {
        return $"{Name}: {HP}/{MaxHP} HP";
    }
}

public class Goblin : Enemy
{
    public Goblin()
    {
        Name = "Гоблин";
        MaxHP = 30;
        HP = MaxHP;
        Attack = 8;
        Defense = 2;
    }

    public override int CalculateDamage(Player player)
    {
        if (random.Next(100) < 15)
        {
            Console.WriteLine("Критический удар!");
            return Attack * 2;
        }
        return Attack;
    }
}

public class Skeleton : Enemy
{
    public Skeleton()
    {
        Name = "Скелет";
        MaxHP = 25;
        HP = MaxHP;
        Attack = 10;
        Defense = 3;
        IgnoreDefense = true;
    }
}

public class Mage : Enemy
{
    public Mage()
    {
        Name = "Маг";
        MaxHP = 20;
        HP = MaxHP;
        Attack = 12;
        Defense = 1;
    }

    public override bool TryFreezePlayer()
    {
        return random.Next(100) < 20;
    }
}

public class BossGoblin : Enemy
{
    public BossGoblin()
    {
        Name = "ВВГ Босс-Гоблин";
        MaxHP = 60;
        HP = MaxHP;
        Attack = 12;
        Defense = 2;
    }

    public override int CalculateDamage(Player player)
    {
        if (random.Next(100) < 25)
        {
            Console.WriteLine("Критический удар босса!");
            return Attack * 2;
        }
        return Attack;
    }
}

public class BossSkeleton : Enemy
{
    public BossSkeleton()
    {
        Name = "Ковальский Босс-Скелет";
        MaxHP = 62;
        HP = MaxHP;
        Attack = 13;
        Defense = 4;
        IgnoreDefense = true;
    }
}

public class BossMage : Enemy
{
    public BossMage()
    {
        Name = "Архимаг C++";
        MaxHP = 36;
        HP = MaxHP;
        Attack = 19;
        Defense = 1;
    }

    public override bool TryFreezePlayer()
    {
        return random.Next(100) < 30;
    }
}

public class BossSkeleton2 : Enemy
{
    public BossSkeleton2()
    {
        Name = "Пестов С--";
        MaxHP = 32;
        HP = MaxHP;
        Attack = 18;
        Defense = 1;
        IgnoreDefense = true;
    }

    public override bool TryFreezePlayer()
    {
        return random.Next(100) < 35;
    }
}

public static class EnemyFactory
{
    private static Random random = new Random();

    public static Enemy CreateRegularEnemy()
    {
        return random.Next(3) switch
        {
            0 => new Goblin(),
            1 => new Skeleton(),
            _ => new Mage()
        };
    }

    public static Enemy CreateBoss()
    {
        return random.Next(4) switch
        {
            0 => new BossGoblin(),
            1 => new BossSkeleton(),
            2 => new BossMage(),
            _ => new BossSkeleton2()
        };
    }
}

