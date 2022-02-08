using ASimpleRPG.Entities;
using System;
namespace ASimpleRPG.Items;
public abstract class Weapon : Item
{
    public int @base = -69, dice, sides, baseAC = -420;
    public DamageType damageType;
    #region Traits
    public bool finesse = false, agile = false;
	private Modifier damageModifier, ACModifier;
	#endregion
    private Weapon(uint amount) : base(amount)
	{
        dealDamage = FirstDamage;
    }
	public Weapon(byte dice, byte sides, Modifier damageModifier, Modifier ACModifier, uint amount) : this(amount)
    {
		// Finesse should be manually set by { } after creation, hence needing a delegate. Used to remove clutter. 
		this.damageModifier = damageModifier;
		this.ACModifier = ACModifier;
        this.sides = sides;
        this.dice = dice;
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
			_ => throw new ArgumentException("Invalid Weapon Damage Modifier Type!")
		};
        baseAC = ACModifier.type switch {
            Stats.Strength => finesse ? damageModifier.calculatedModifier / 2 : damageModifier.calculatedModifier,
            Stats.Dexterity => finesse ? damageModifier.calculatedModifier : damageModifier.calculatedModifier / 2,
            _ => throw new ArgumentException("Invalid Weapon AC Modifier Type!")
        };
        if (agile) baseAC += 3;
    	dealDamage = SubsequentDamage;
		return SubsequentDamage(); 
    }
    protected virtual Damage SubsequentDamage() => new(damageType, @base + (dice * Random.Next(1, sides + 1)), Random.Next(1, 21) + baseAC);
    public override string ToString() => base.ToString() + $"\n{damageType} based\nbase: {@base}, ACBase: {baseAC}\nRolls {dice} {sides}-sided dice";
}
/// <summary>
/// 
/// </summary>
