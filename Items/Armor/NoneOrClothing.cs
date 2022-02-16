namespace ASimpleRPG.Items;
using System;
using ASimpleRPG.Entities;
public class PeasantClothing : None
{
	public PeasantClothing(uint amount) : base(amount) { }
}
public class TravelersClothing : None, IPurchasable
{
	public TravelersClothing(uint amount) : base(amount) { }
	public float Cost => 50;
	public float Amount => amount;
}
public abstract class None : Armor
{
	public None(uint? amount = null) : base(new Resistances(), new StatusEffects(null, null, null), 0, amount ?? 0) 
	{
		rarity = Rarity.Unique;
		name = "Naked";
		description = "Doesn't have any clothing on you, you just have your private parts swaying in the wind!";
	}
}
