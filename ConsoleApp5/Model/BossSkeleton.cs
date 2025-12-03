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