namespace ASimpleRPG.Items;


public sealed class SavingGrace : Weapon, IPurchasable
{
	public SavingGrace(Modifier generalModifier, uint amount) : base(1, 12, generalModifier, generalModifier, amount, false)
	{
		agile = true;
		name = "Saving Grace";
		description = "A flimsy 2-handed longsword";
		damageType = DamageType.Physical;
	}
	public float Cost => 150;

	public float Amount => amount;
}