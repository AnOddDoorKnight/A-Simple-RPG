using System;
using System.Collections.Generic;
namespace ASimpleRPG.Entities.Random;
public static class ItemGenerator
{
    private static Random Random = new();
    public static Weapon Next(ItemType itemType) => itemType switch
    {
        _ => throw new NotImplementedException();
    };
    // Gets Random Itemtype for Next
    public static Weapon Next() => Next((ItemType)Random.Next(Enum.GetNames<ItemType>().Length));
}
public enum ItemType
{
    Consumable,
    Armor,
    Weapon,
    Spell
}