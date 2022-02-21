using ASimpleRPG.Items;
using System.Collections.Generic;
using System;
using static OddsLibrary.Algebra.Algebra;
namespace ASimpleRPG.Entities;
/// <summary>
/// Base class for humans, inherits <seealso cref="Entity"/>
/// </summary>
public class Human : Entity
{
	private Weapon? _weapon = null;
	public Weapon EquippedWeapon { get => _weapon ?? new Fists(FindModifierForFists(), FindModifierForFists()); set => _weapon = value; }
	private Armor armor = new None();
	public Armor Armor { get => armor; set
		{
			Armor oldArmor = armor;
			armor = value;
			// AC
			armorAC += value.AC - oldArmor.AC;
		} }
	public Dictionary<Stats, Stat> Stats = new();
    public Human(HealthData? healthData, StatusEffects? statusEffects, Resistances? resistances) 
	: base(healthData ?? new HealthData(15), statusEffects ?? new StatusEffects(100, 100, 100), resistances ?? new Resistances())
    {
		foreach (Stats i in Enum.GetValues(typeof(Stats)))
			Stats.Add(i,new Stat(10));
    }
	internal Modifier FindModifierForFists() => 
		Stats[ASimpleRPG.Stats.Strength].Modifier < Stats[ASimpleRPG.Stats.Dexterity].Modifier ? 
		new Modifier(ASimpleRPG.Stats.Dexterity, Stats[ASimpleRPG.Stats.Dexterity].Modifier) : 
		new Modifier(ASimpleRPG.Stats.Strength, Stats[ASimpleRPG.Stats.Strength].Modifier);
}