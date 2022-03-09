namespace ASimpleRPG.Items;


public class Fists : Weapon
{
	public override string? Name => "Fists";
	public override string? Description =>
		"Hands given form to be best described as tiny flesh hammers.";
	public override int BaseDamage => 17;
	public override DamageType DamageType => DamageType.Bludgeoning;
	public override float? Weight => 0f;
	public override float? ScalarStrength => 0.4f;
	public override float? ScalarDexterity => 0.2f;
	public override uint? StrengthRequirement => null;
	public override uint? DexterityRequirement => null;
	public Fists(StatDataPackage damageModifier, StatDataPackage ACModifier) 
	{
		availibleTraits[Traits.Finesse] = true;
		availibleTraits[Traits.Agile] = true;
	}
}