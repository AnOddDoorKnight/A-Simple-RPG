namespace ASimpleRPG.Items;
public sealed class HeavyBranch : Weapon
{
    public HeavyBranch(Modifier generalModifier, uint amount) : base(1, 6, generalModifier, generalModifier, amount, null)
	{
        name = "Heavy Branch";
        description = "A stubby branch cut off from a large oak tree, the wood still feels fresh." 
        + " You would have a better chance using the tool that cut it than using this as a weapon.";
        damageType = DamageType.Bludgeoning;
	}
}