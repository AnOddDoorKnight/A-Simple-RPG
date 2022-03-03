namespace ASimpleRPG.Items;
using System;
using Entities;


public class PeasantClothing : None
{
	public PeasantClothing()
	{
		tier = TierArmor.Cloth;
		name = "Peasant's Clothing";
		statusInfluences = new StatusEffects(10, 10, null);
	}
}


public class TravelersClothing : None, IPurchasable
{
	public TravelersClothing()
	{
		tier = TierArmor.Cloth;
		statusInfluences = new StatusEffects(10, 12, null);
	}
	public float Cost => 50;
	public float Amount => amount;
}


public class None : Armor
{
	public None() : base(new Resistances(), new StatusEffects(null, null, null), 0) 
	{
		tier = TierArmor.None;
		rarity = Rarity.Unique;
		name = "Naked";
		description = "Doesn't have any clothing on you, you just have your private parts swaying in the wind!";
	}
}
