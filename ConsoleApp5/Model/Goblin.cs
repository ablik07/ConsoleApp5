using System;

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
        if (RandomClass.PercentChance(15))
        {
            Console.WriteLine("Критический удар!");
            return Attack * 2;
        }
        return Attack;
    }
}