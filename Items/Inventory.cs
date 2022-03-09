namespace ASimpleRPG.Items;

using System.Collections.Generic;


public class Inventory
{
	public List<Weapon> Weapons = new();
	public List<Armor> Armors = new();
	public List<Ring> Rings = new();
	public ConsumableList Consumables = new();
}
public class ConsumableList : Dictionary<string, Consumable>
{
	public void Add(Consumable consumable)
	{
		if (ContainsValue(consumable))
			Add(nameof(consumable), consumable);
		else
			this[nameof(consumable)].amount += consumable.amount;
	}
}