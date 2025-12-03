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