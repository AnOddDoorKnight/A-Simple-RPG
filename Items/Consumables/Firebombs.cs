namespace ASimpleRPG.Items;


public class Firebomb : Consumable
{
	public override uint MaxUses { get; set; } = 99;
	public Firebomb(uint amount) : base(amount)
	{

	}
}


public class BlackFirebomb : Firebomb
{
	public BlackFirebomb(uint amount) : base(amount)
	{

	}
}