using ASimpleRPG.Entities;
namespace ASimpleRPG.Items;
public abstract class Armor : Item
{
    public uint AC;
    public Resistances resistances;
    public StatusEffects statusInfluences;
    public TierArmor tier;
    public Armor(Resistances resistances, StatusEffects statusInfluences, uint AC, uint amount) : base(amount) 
    {
        this.resistances = resistances;
        this.statusInfluences = statusInfluences;
        this.AC = AC;
    }
}
public enum TierArmor : byte
{
    None,
    Cloth,
    Chainmail,
    Plate,
    Jouster
}