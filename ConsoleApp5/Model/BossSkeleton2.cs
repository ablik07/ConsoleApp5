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

    public override bool TryFreezePlayer() => RandomClass.PercentChance(35);
}