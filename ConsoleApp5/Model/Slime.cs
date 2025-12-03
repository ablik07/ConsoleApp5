public class Slime : Enemy
{
    public Slime()
    {
        Name = "Слизень";
        MaxHP = 40;
        HP = MaxHP;
        Attack = 6;
        Defense = 1;
    }

    public override void TakeDamage(int damage)
    {
        int reducedDamage = damage - 2;
        if (reducedDamage < 1) reducedDamage = 1;
        HP -= reducedDamage;
    }
}