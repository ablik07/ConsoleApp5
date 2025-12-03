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

    public override bool TryFreezePlayer() => RandomClass.PercentChance(30);
}