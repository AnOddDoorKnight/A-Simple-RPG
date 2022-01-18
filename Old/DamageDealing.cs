namespace ASimpleRPG;
public enum damageType
{
	Physical,
	Slashing,
	Piercing,
	Bludgeoning,
    Magic,
    Fire,
    Lightning,
    Dark
}
public struct Damage
{
    public damageType;
    public short Value { get; init; }
    public readonly short @base, damage;
    public readonly byte dice;
    public Damage(damageType damageType; short @base, short damage, byte dice)
    {   // Base Values
        this.damageType = damageType;
        this.@base = @base;
        this.damage = damage;
        this.dice = dice;
        // Generating Damage Package
        Random Random = new();
        short total = @base + modifier;
        for (int i = 0; i < dice; i++)
            total += Random.Next(1, damage + 1);
        Value = total; 
    }
}
/// <summary>
/// This is for calculating and holding damage. While all most numbers are important to
/// create one, you need only the Value and the damageType for resistances.
/// </summary>
/*
public struct DamageType
{
	public readonly damageType[] types;
    public PhysicalDamageType this[int index] => type.Length == 1 ? type[0] : type[index];
	public DamageType(damageType[] types)
	{
		this.elementalType = elementalType;
		type = types;
	}
	public DamageType(PhysicalDamageType type, ElementalDamageType? elementalType = null) 
	{
		this.elementalType = elementalType;
		this.type = new PhysicalDamageType[] {type};
	}
}
/// <summary>
/// This tracks the damage-type that is nesaccary for armor and resistances/weaknesses
/// Be sure to bring it with the damage itself. For split damage, bring two structs of Damage for
/// The additional elemental damage, or it can be pure elemental damage (although not implemented).
///
/// To create one, be sure to include at least one regular PhysicalDamageType or more via arrays
/// if you have Variable attacks. It's [0] by default and any additional ones is for variables.
/// ie DamageType[0] for physical, DamageType[1] for thrust
///
/// Also, elemental seems to be broken, but oh well
/// </summary>
*/