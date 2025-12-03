using System;

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
        if (RandomClass.PercentChance(25))
        {
            Console.WriteLine("Критический удар босса!");
            return Attack * 2;
        }
        return Attack;
    }
}