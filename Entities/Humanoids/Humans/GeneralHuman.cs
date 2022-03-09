namespace ASimpleRPG.Entities;

using ASimpleRPG.Items;
using System.Collections.Generic;
using System;


/// <summary>Base class for humans, inherits <seealso cref="Entity"/></summary>
public abstract class Human : Entity
{
	private Weapon? _weapon = null;
	/// <summary>
	/// Currently Equipped Weapon, 
	/// uses <see cref="Fists"/> as Default if it doesn't exist
	/// </summary>
	public Weapon EquippedWeapon
	{
		get => _weapon ?? fists;
		set => _weapon = value;
	}
	private Fists fists;
	private Armor armor = new None();
	/// <summary>
	/// The equipped <see cref="Armor"/> that the human is wearing
	/// </summary>
	public Armor Armor
	{
		get => armor;
		set
		{
			Armor oldArmor = armor;
			armor = value;
			// AC
			armorAC += value.AC - oldArmor.AC;
		}
	}
	public Dictionary<Stats, Stat> Stats = new()
	{
		[ASimpleRPG.Stats.Vigor] = new Stat(10),
		[ASimpleRPG.Stats.Mind] = new Stat(10),
		[ASimpleRPG.Stats.Endurance] = new Stat(10),
		[ASimpleRPG.Stats.Strength] = new Stat(10),
		[ASimpleRPG.Stats.Dexterity] = new Stat(10),
		[ASimpleRPG.Stats.Intelligence] = new Stat(10),
		[ASimpleRPG.Stats.Faith] = new Stat(10),
		[ASimpleRPG.Stats.Arcane] = new Stat(10)
	};
	//: base(healthData ?? new HealthData(15), statusEffects ?? new StatusEffects(100, 100, 100), resistances ?? new Resistances())
	public Human()
	{
		fists = new Fists(FindModifierForFists(), FindModifierForFists());
	}
	internal int FindModifierForFists()
	{
		if (Stats[ASimpleRPG.Stats.Strength].AsStrength().strengthPower <
			Stats[ASimpleRPG.Stats.Dexterity].AsDexterity())
			return new Modifier(ASimpleRPG.Stats.Dexterity, Stats[ASimpleRPG.Stats.Dexterity].AsDexterity());
new Modifier(ASimpleRPG.Stats.Strength, Stats[ASimpleRPG.Stats.Strength].Modifier);
	}
}