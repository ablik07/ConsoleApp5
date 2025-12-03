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

    public override bool TryFreezePlayer() => RandomClass.PercentChance(20);
}