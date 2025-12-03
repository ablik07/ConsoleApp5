using System;

public abstract class Item
{
    public string Name { get; set; }
    public virtual void Use(Player player) { }
    public override string ToString() => Name;
}