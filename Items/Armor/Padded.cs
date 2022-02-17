namespace ASimpleRPG.Items;
using System.Collections.Generic;
using ASimpleRPG.Entities;
public class Padded : Armor
{
	static readonly Dictionary<DamageType, int> preset = 
		new Dictionary<DamageType, int>() 
		{ 
			[DamageType.Physical] = 24, 
			[DamageType.Thrusting] = 16, 
			[DamageType.Slashing] = 22,
			[DamageType.Bludgeoning] = 34,
			[DamageType.Bleeding] = 24,
			[DamageType.Poison] = 20,
		};
public Padded() : 
		base(new Resistances(preset))
	{

	}
}