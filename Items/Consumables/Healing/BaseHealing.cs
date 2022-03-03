namespace ASimpleRPG.Items;


public abstract class HealingItem : Consumable
{
	public HealingItem(DelHealAmount healAmount, uint amount) : base(amount)
	{
		HealAmount = healAmount;
	}
	public delegate void DelHealAmount(uint heal);
	public DelHealAmount HealAmount;
}
