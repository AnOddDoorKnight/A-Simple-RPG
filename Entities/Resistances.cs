namespace ASimpleRPG.Entities;
using System;
using System.Collections.Generic;
/// <summary>
/// 
/// </summary>
public struct Resistances
{
	public int this[DamageType type] { get => list[type]; set => list[type] = value; }
	public Dictionary<DamageType, int> list = new();
	public Resistances(Dictionary<DamageType, int>? list = null)
	{
		foreach (int i in Enum.GetValues<DamageType>())
			if (this.list.ContainsKey((DamageType)i) && list != null) 
				this.list[(DamageType)i] = list[(DamageType)i]; 
			else 
				this.list.Add((DamageType)i, i);
	}
	public float GetNewValue(float input, DamageType type) =>
		type == DamageType.Bludgeoning ? input - list[DamageType.Bludgeoning] : input - (input - list[type]);
}