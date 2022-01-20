using ASimpleRPG.Entities;
using System;
namespace ASimpleRPG.Items;
public sealed class SavingGrace : Weapon
{
    
}
public sealed class HeavyBranch : Weapon
{
    public HeavyBranch(Modifier generalModifier) : base(new WeaponDataPackage(1, 6), generalModifier, generalModifier)
	{
        name = "Heavy Branch";
        description = "Feels heavy for a wooden branch, may crack a skull";
        damageType = DamageType.Bludgeoning;
	}
}
public abstract class Weapon : Item
{
    public int @base, dice, sides, baseAC;
    public DamageType damageType;
    #region Traits
    public bool finesse = false;
	#endregion
	public Weapon(WeaponDataPackage data, Modifier damageModifier, Modifier ACModifier)
    {
		//Weapon Modifier
		@base = damageModifier.type switch {
			Stats.Strength => damageModifier.calculatedModifier,
			Stats.Dexterity => finesse ? damageModifier.calculatedModifier : throw new ArgumentException(),
			_ => throw new ArgumentException("Invalid Weapon Damage Modifier Type!")
		};
        baseAC = ACModifier.type switch {
            Stats.Strength => finesse ? damageModifier.calculatedModifier / 2 : damageModifier.calculatedModifier,
            Stats.Dexterity => finesse ? damageModifier.calculatedModifier : damageModifier.calculatedModifier / 2,
            _ => throw new ArgumentException("Invalid Weapon AC Modifier Type!")
        };
        sides = data.sides;
        dice = data.dice;
	}
    public virtual Entities.Damage DealDamage() => new(damageType, @base + (dice * Random.Next(1, sides + 1)), Random.Next(1, 21) + baseAC);
    public override string ToString() => base.ToString() + $"\n{damageType} based\nbase: {@base}, ACBase: {baseAC}\nRolls {dice} {sides}-sided dice";
}
/// <summary>
/// 
/// </summary>
public struct WeaponDataPackage
{

    public int dice, sides;
    public WeaponDataPackage(int dice, int sides)
	{
        this.dice = dice;
        this.sides = sides;
	}
}
public struct Modifier
{
    public Stats type;
    public sbyte calculatedModifier;
    public Modifier(Stats type, sbyte calculatedModifier)
	{
        this.type = type;
        this.calculatedModifier = calculatedModifier;
	}
}