using ASimpleRPG.Entities;
using System;
namespace ASimpleRPG.Items;
public abstract class Weapon : Item
{
    public int @base = -69, dice, sides, baseAC = -420;
    public DamageType damageType;
    #region Traits
    public bool finesse = false;
	#endregion
	public Weapon(byte dice, byte sides, Modifier damageModifier, Modifier ACModifier, uint amount) : base(amount)
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
    #warning TODO: #6 Set a method for setting the bool finesse for items
    public virtual Entities.Damage DealDamage() => new(damageType, @base + (dice * Random.Next(1, sides + 1)), Random.Next(1, 21) + baseAC);
    public override string ToString() => base.ToString() + $"\n{damageType} based\nbase: {@base}, ACBase: {baseAC}\nRolls {dice} {sides}-sided dice";
}
/// <summary>
/// 
/// </summary>