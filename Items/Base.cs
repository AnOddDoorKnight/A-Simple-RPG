using System;
namespace ASimpleRPG.Items;
public abstract class Item
{
	protected static readonly Random Random = new();
	public string? name, description;
	public Rarity rarity = Rarity.Common;
	public uint amount;
	public Item(uint amount)
	{
		this.amount = amount;
	}
	public override string ToString() => $"{name}\n{description}";
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