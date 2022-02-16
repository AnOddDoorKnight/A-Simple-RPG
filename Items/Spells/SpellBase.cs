namespace ASimpleRPG.Items.Spells;
public abstract class Spell
{
	public uint FPCost;
	public Spell(uint FPCost)
	{
		this.FPCost = FPCost;
	}
}