namespace ASimpleRPG.Items;


public sealed class HeavyBranch : Weapon
{
	public override string? Name => "Heavy Branch";
	public override string? Description => "A stubby branch cut off from a " +
		"large oak tree, the wood still feels fresh. \n You would have a " +
		"better chance using the tool that cut it than using this as a weapon.";
	public override DamageType DamageType => DamageType.Bludgeoning;
	public override uint? StrengthRequirement => 8;
	public override float? Weight => 1f;
	public HeavyBranch(StatDataPackage generalModifier)
	{

	}
}