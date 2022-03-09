namespace ASimpleRPG.Items;

using System;


/// <summary>
/// The Base structure of all items in the game, going from <see cref="Armor"/>,
/// <see cref="Weapon"/>, and <see cref="Consumable"/>. Provides a static random
/// class and gives the base <see cref="Name"/>, <see cref="Description"/>,
/// <see cref="Rarity"/> and <see cref="Weight"/>
/// </summary>
public abstract class Item
{
	protected static readonly Random Random = new();
	public abstract string? Name { get; }
	public abstract string? Description { get; }
	public virtual Rarity Rarity => Rarity.Common;
	public abstract float? Weight { get; }
	public override string ToString() => $"{Name}\n{Description}";
}
public enum Rarity : sbyte
{
	Dev = -2,
	Unique = -1,
	Common = 0,
	Uncommon,
	Rare
}
public interface IPurchasable
{
	float Cost { get; }
	float Amount { get; }
	float Bulk => Cost * Amount;
}