namespace ASimpleRPG.Items;


public sealed class Longsword : Weapon, IPurchasable
{
	public override string? Name => "Longsword";
	public override string? Description => "Popular and most commonly crafted"+
		" longsword.\nCommonly used as a backup weapon, as polearms like the" +
		" billhook are more effective in combat or other prepared aggressive" +
		" negotiations";
	public override TypeOfWeapon Type => TypeOfWeapon.Straight_Sword;
	public override float? Weight => 1.4f;
	public override int RangeTiles => 1;
	public override int BaseDamage => 112;
	public override uint? StrengthRequirement => 10;
	public override uint? DexterityRequirement => 12;
	public override float? ScalarStrength => 2.65f;
	public override float? ScalarDexterity => 2.75f;


	public Longsword(StatDataPackage generalModifier)
	{
		availibleTraits[Traits.Agile] = true;
	}
	public float Cost => 150;

	public float Amount => amount;
}