public abstract class Enemy
{
    public string Name { get; protected set; }
    public int HP { get; protected set; }
    public int MaxHP { get; protected set; }
    public int Attack { get; protected set; }
    public int Defense { get; protected set; }
    public bool IgnoreDefense { get; protected set; }
    public bool IsAlive => HP > 0;

    public virtual int CalculateDamage(Player player) => Attack;

    public virtual bool TryFreezePlayer() => false;

    public virtual void TakeDamage(int damage) => HP -= damage;

    public string GetStatus() => $"{Name}: {HP}/{MaxHP} HP";
}