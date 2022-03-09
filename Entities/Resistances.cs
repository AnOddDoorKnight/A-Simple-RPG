namespace ASimpleRPG.Entities;

using System;
using System.Collections.Generic;


public struct Resistances
{
	public int this[DamageType type] { get => list[type]; set => list[type] = value; }
	public Dictionary<DamageType, int> list = new();
	public Resistances() : this(null)
	{

	}
	public Resistances(Dictionary<DamageType, int>? list)
	{
		foreach (int i in Enum.GetValues<DamageType>())
			if (this.list.ContainsKey((DamageType)i) && list != null) 
				this.list[(DamageType)i] = list[(DamageType)i]; 
			else 
				this.list.Add((DamageType)i, i);
	}
	public float GetNewValue(float input, DamageType type) => 
		GetDamageCategory(type) switch
		{
			DamageCategory.Standard => input - (input - list[type]),
			DamageCategory.Bludgeoning => input - list[type],
			DamageCategory.StatusEffect => input - list[type], // This should be different
			_ => throw new ArgumentOutOfRangeException(nameof(type)),
		};

	public static DamageCategory GetDamageCategory(DamageType type) => type switch
	{   // Bludgeoning
		DamageType.Bludgeoning => DamageCategory.Bludgeoning,
		// Status Effects
		DamageType.Bleeding => DamageCategory.StatusEffect,
		DamageType.Cursed => DamageCategory.StatusEffect,
		DamageType.Poison => DamageCategory.StatusEffect,
		// Default
		_ => Entities.DamageCategory.Standard
	};
}
public enum DamageCategory
{
	Standard,
	Bludgeoning,
	StatusEffect
}