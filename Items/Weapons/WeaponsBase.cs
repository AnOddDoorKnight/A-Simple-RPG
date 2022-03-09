namespace ASimpleRPG.Items;

using Entities;
using System;
using System.Collections.Generic;


public abstract class Weapon : Item
{
	public virtual DamageType DamageType => DamageType.Physical;
	public abstract int BaseDamage { get; }
	public abstract TypeOfWeapon Type { get; }
	public Weapon()
	{

	}
	public Dictionary<Traits, bool> availibleTraits = new()
	{
		[Traits.Finesse] = false,	// Allows you to use dex as hit AC
		[Traits.Agile] = false,		// Lessens multiple attack penalty by -1
	};
	// As the game is tile-based, we need some sort of range that weapons can
	// Work by. unfortunately, there is no real set measurement in the world.
	public abstract int RangeTiles { get; }


	// This is the scaling of the weapon. Because you cannot upgrade weapons
	// due To Realism, you can make it more effective by upgrading stats.
	// Scaling Works independently of the base damage, rather weapons like
	// Incredibly Heavy Weapons Tends to have S Scaling
	public abstract float? ScalarStrength { get; }
	public abstract float? ScalarDexterity { get; }
	public virtual float? ScalarIntelligence => null;
	public virtual float? ScalarFaith => null;
	// Returns a value that allows the player to guess how good the scaling is
	// With certain weapons
	public char GetGrade(Stats stat)
	{
		float? input = stat switch
		{
			Stats.Strength => ScalarStrength,
			Stats.Dexterity => ScalarDexterity,
			Stats.Intelligence => ScalarIntelligence,
			Stats.Faith => ScalarFaith,
			_ => throw new IndexOutOfRangeException()
		};
		if (!input.HasValue) return ' ';
		float newInput = input.Value;
		// This just kills my soul, but i don't know anything better than this
		if (newInput <= 0	)	return 'F';
		if (newInput <= 0.5f)	return 'E';
		if (newInput <= 1.5f)	return 'D';
		if (newInput <= 3f	)	return 'C';
		if (newInput <= 5f	)	return 'B';
		if (newInput <= 7.5f)	return 'A';
		return 'S';
	}
	// This is for figuring out if the player has enough stats to wield 
	public abstract uint? StrengthRequirement { get; }
	public abstract uint? DexterityRequirement { get; }
	public virtual uint? FaithRequirement { get; }
	public virtual uint? IntelligenceRequirement { get; }
	public virtual uint? ArcaneRequirement { get; }
}
public enum TypeOfWeapon
{
	Fists,
	Dagger,
	Curved_Sword,
	Straight_Sword,
	Greatsword,
	Curved_Greatsword,
	Colossal_Sword,
	Colossal_Greatsword,
	Hammer,
	Warhammer,
	Axe,
	Greataxe,
	Polearm,
	Scythe,
	Spear,
	Greatspear,
	Whip,
	Greatwhip,
	Small_Shield,
	Medium_Shield,
	Greatshield,
	Light_Bow,
	Heavy_Bow,
	Greatbow,
	Crossbow,
	Ballista
}
public enum Traits
{
	Finesse,
	Agile,
}
/*
public abstract class Weapon : Item
{
	public int @base = -69, dice, sides, baseAC = -420;
	public DamageType damageType;
	#region Traits
	public bool finesse = false, agile = false;
	public bool? isOneHanded;
	private StatDataPackage damageModifier, ACModifier;
	#endregion
	private Weapon(uint amount) : base(amount)
	{
		dealDamage = FirstDamage;
	}
	public Weapon(byte dice, byte sides, StatDataPackage damageModifier, StatDataPackage ACModifier, uint amount, bool? isOneHanded) : this(amount)
	{
		// Finesse should be manually set by { } after creation, hence needing a delegate. Used to remove clutter. 
		this.damageModifier = damageModifier;
		this.ACModifier = ACModifier;
		this.sides = sides;
		this.dice = dice;
		this.isOneHanded = isOneHanded;
	}
	// Damage Logic
	public delegate Damage DdealDamage();
	public Damage DealDamage() => dealDamage(); // Method as readonly delegate
	private DdealDamage dealDamage; // Delegate here
	protected virtual Damage FirstDamage()
	{	// This gets called first before doing any other attacks
		@base = damageModifier.type switch {
			Stats.Strength => damageModifier.calculatedModifier,
			Stats.Dexterity => finesse ? damageModifier.calculatedModifier : throw new ArgumentException(),
			_ => throw new ArgumentException("Invalid Weapon Damage StatDataPackage Type!")
		};
		baseAC = ACModifier.type switch {
			Stats.Strength => finesse ? damageModifier.calculatedModifier / 2 : damageModifier.calculatedModifier,
			Stats.Dexterity => finesse ? damageModifier.calculatedModifier : damageModifier.calculatedModifier / 2,
			_ => throw new ArgumentException("Invalid Weapon AC StatDataPackage Type!")
		};
		if (agile) baseAC += 3;
		dealDamage = SubsequentDamage;
		return SubsequentDamage(); 
	}
	protected virtual Damage SubsequentDamage() => new(damageType, @base + (dice * Random.Next(1, sides + 1)), Random.Next(1, 21) + baseAC);
	public override string ToString() => base.ToString() + $"\n{damageType} based\nbase: {@base}, ACBase: {baseAC}\nRolls {dice} {sides}-sided dice";
}
*/
