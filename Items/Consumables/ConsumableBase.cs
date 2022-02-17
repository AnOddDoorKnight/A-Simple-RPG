namespace ASimpleRPG.Items;
using OddsLibrary.Algebra;
public abstract class Consumable : Item
{
	public abstract uint MaxUses { get; set; }
	public uint Uses { get => amount; set => amount = (uint)Algebra.LimitValue(value, 0, MaxUses); }
	public Consumable(uint amount) : base(amount)
	{
		Uses = amount;
	}
	public abstract void Use();
	internal void DepleteItem() => amount--;
}