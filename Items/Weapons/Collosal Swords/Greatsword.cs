namespace ASimpleRPG.Items;


public class Greatsword : Weapon
{
	public override string? Name => "Greatsword";
	public override string Description => "Placeholder Description, but you"
		+ " be stronk to wield this";
	public override int BaseDamage => 260;
	public override int RangeTiles => 3;
	public override Rarity Rarity => Rarity.Rare;
	public override TypeOfWeapon Type => TypeOfWeapon.Colossal_Sword;
	public override DamageType DamageType => DamageType.Physical;
	public override float? ScalarStrength => 6.2f;
	public override float? ScalarDexterity => 0.2f;
	public override uint? StrengthRequirement => 31;
	public override uint? DexterityRequirement => 8;
	public override float? Weight => 31;
}