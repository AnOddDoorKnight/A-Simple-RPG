using ASimpleRPG.Entities;
using ASimpleRPG.Entities.Char;
using System.Collections.Generic;

namespace ASimpleRPG.Objects;


public static class ItemLibrary
{
    public static virtual Item this[ItemEnum wantedItem, byte Quantity = 1]
    {
        get => wantedItem switch 
        {
            ItemEnum.F3ootStick => new F3ootStick(Quantity),
            ItemEnum.Fist => new Fists(),
            ItemEnum.SavingGrace => new SavingGrace(Quantity)
        };
    }

}
public enum ItemEnum
{
    F3ootStick,
    Fist,
    SavingGrace,
}
#region Items
#region Weapons
public sealed class QuarterStaff : Weapon
{
	public QuarterStaff(byte amount = 1) : base(Stats.StatType.Strength, new DamageType(PhysicalDamageType.Bludgeoning), new Damage(0, 4, 1), amount)
	{
		name = "Quarterstaff";
		description = "7.5 foot stick. Incredibly fast and a viable weapon, at least for just a stick.";
		rarity = Rarity.Common;
		// Add valid prices and mass!
		massPerItem = 1f;
		cost = null;
		// Damage numbers and values
	}
}
public sealed class F3ootStick : Weapon
{
    public F3ootStick(byte amount = 1) : base(amount) 
    { 
		name = "3-Foot Stick";
        description = "A step below a quarterstaff. More like a dimestaff, really. Commonly used for hatchets and such.";
		rarity = Rarity.Common;
		massPerItem = 0.5f;
    }
}
public sealed class Fists : Weapon
{
    public Fists()
    {
        name = "Fists";
        description = "Your bare hands, don't go swordfighting with them.";
    }
}
public sealed class SavingGrace : Weapon
{
    public SavingGrace(byte amount) : base(amount) 
    { 
        name = "Saving Grace";
        description = "Fragile longsword thats relatively cheap to make. Commonly used by knight wannabes.";
    }
}
public abstract class Weapon : Item
{
	public DamageType damageType;
    public short @base, damage;
    public byte dice;
    public virtual int Swing()
	{
        Random Random = new();
        int totalDamage = @base;
        for (int i = 1; i <= dice; i++)
            totalDamage += Random.Next(1, damage);
        return totalDamage;
    }
    // Should be updated whenever the player is using it!
    public Weapon ( Stats.StatType Modifier, damageType damageType, byte amount = 1) : base(amount) 
	{
		this.damageType = damageType;
		@base = damage.@base;
		this.damage = damage.damage;
		dice = damage.dice;
	}
}
#endregion
public abstract class Item
{
    // Itentifying Information
    public string? name = null,
        description = null;
    public Rarity? rarity = null;
    // Amount & Mass
    public float? massPerItem => null;
    private byte _quantity = 1;
    public byte Quantity 
    { 
        get => _quantity; 
        set => _quantity = value;
    }
    public float Mass => massPerItem ?? 0 * Quantity;
    public uint? cost = null;
    public virtual void Display() 
    {

    }
    // Initializer/Constructor
    public Item(byte quantity = 1) => Quantity = quantity;
}
#endregion
public enum Rarity : sbyte
{
    Dev = -2,
    Unique = -1,
    Common = 0,
    Uncommon,
}
public enum ItemType : byte
{
    Weapon,
    Armor,
    Emblem,
    Consumable,
    Junk,
}