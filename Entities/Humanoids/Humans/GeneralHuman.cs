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
		get => _weapon ?? 
			new Fists(FindModifierForFists(), FindModifierForFists()); 
		set => _weapon = value; 
	}
	private Armor armor = new None();
	/// <summary>
	/// The equipped <see cref="Armor"/> that the human is wearing
	/// </summary>
	public Armor Armor 
	{ 
		get => armor; set
		{
			Armor oldArmor = armor;
			armor = value;
			// AC
			armorAC += value.AC - oldArmor.AC;
		} 
	}
	public Dictionary<Stats, Stat> Stats = new();
    public Human(HealthData? healthData, StatusEffects? statusEffects, Resistances? resistances) 
	: base(healthData ?? new HealthData(15), statusEffects ?? new StatusEffects(100, 100, 100), resistances ?? new Resistances())
    {
		foreach (Stats i in Enum.GetValues(typeof(Stats)))
			Stats.Add(i,new Stat(10));
    }
	internal Modifier FindModifierForFists() => 
		Stats[ASimpleRPG.Stats.Strength].AsStrength() < Stats[ASimpleRPG.Stats.Dexterity].AsDexterity() ? 
		new Modifier(ASimpleRPG.Stats.Dexterity, Stats[ASimpleRPG.Stats.Dexterity].Modifier) : 
		new Modifier(ASimpleRPG.Stats.Strength, Stats[ASimpleRPG.Stats.Strength].Modifier);
}