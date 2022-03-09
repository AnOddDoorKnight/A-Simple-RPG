namespace ASimpleRPG.Items;
using OddsLibrary.Algebra;


public abstract class Consumable : Item
{
	public abstract uint MaxUses { get; set; }
	public uint amount;
	public uint Uses { get => amount; set => amount = (uint)Algebra.LimitValue(value, 0, MaxUses); }
	public Consumable(uint amount)
	{
		Uses = amount;
	}
	internal void DepleteItem() => amount--;
}