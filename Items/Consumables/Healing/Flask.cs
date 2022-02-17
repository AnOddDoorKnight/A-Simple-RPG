namespace ASimpleRPG.Items;
public class Flask : HealingItem
{
	static readonly uint defaultFlaskSize = 3;
	public override uint MaxUses { get; set; }
	public uint Intensity = 0; 
	public Flask(uint? flaskSize, DelHealAmount healAmount, uint amount) : base(healAmount, amount)
	{
		MaxUses = flaskSize ?? defaultFlaskSize;
	}
	public override void Use() => HealAmount.Invoke(20 + (4 * Intensity));
}
