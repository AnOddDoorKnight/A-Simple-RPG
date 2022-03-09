namespace ASimpleRPG.Items;


public class Firebomb : Consumable
{
	public override string? Name => "Firebomb";
	public override string? Description => "An explosive pot that surrounds an"
		+ " area of around 10 feet in diameter, commonly used by footsoldiers "
		+ "and bandits to clear lines and cause havoc in towns. They were "
		+ "later banned from use.";
	public override uint MaxUses { get; set; } = 99;
	public Firebomb(uint amount) : base(amount)
	{

	}
}


public class BlackFirebomb : Firebomb
{
	public override string? Name => $"Black {base.Name}";
	public override string? Description => $"{base.Description}\n\nThis" +
		"Particular version is a more enchanced version of the firebomb.";
	public BlackFirebomb(uint amount) : base(amount)
	{
		
	}
}