using System;
namespace ASimpleRPG.Items;
public abstract class Item
{
    protected static Random Random = new();
    public string? name, description;
    public Item()
    {
        
    }
    public override string ToString() => $"{name}: {description}";
}
public enum Rarity : sbyte
{
    Dev = -2,
    Unique = -1,
    Common = 0,
    Uncommon,
    Rare
}
public enum ItemType : byte
{
    Weapon,
    Armor,
    Emblem,
    Consumable,
    Junk,
}