namespace ASimpleRPG.Items;

using System;
using Entities;


/// <summary>
///	<para>
/// Armor that is meant to be used for humans. Returns <see cref="AC"/> for
///	difficulty of hitting someone, resistances to determine the reduction of damage,
///	difficulty of being affected by status effects like <see cref="DamageType.Poison"/>
///	and <seealso cref="DamageType.Bleeding"/>, weight of the total armor,
///	stored as <see cref="Item.Weight"/>, and how slow your character moves by
///	using <see cref="TileMovementDecrease()"/>.
///	</para>
/// </summary>
/// <seealso cref="ASimpleRPG.Items.Item" />
public abstract class Armor : Item
{
	public abstract int AC { get; }
	public abstract Resistances Resistances { get; }
	public abstract StatusEffects statusInfluences { get; }
	public TierArmor tier;
	public Armor() : base(0) { }
	public int TileMovementDecrease => -1 * tier switch
	{
		TierArmor.None => 0,
		TierArmor.Cloth => 0,
		TierArmor.Chainmail => 1,
		TierArmor.Plate => 2,
		TierArmor.Jouster => 3,
		_ => throw new ArgumentOutOfRangeException()
	};
}
public enum TierArmor : byte
{
	None,
	Cloth,
	Chainmail,
	Plate,
	Jouster
}