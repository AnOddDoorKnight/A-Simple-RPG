using ASimpleRPG.Entities;
namespace ASimpleRPG.Items;
using System;
public abstract class Armor : Item
{
    public uint AC;
    public Resistances resistances;
    public StatusEffects statusInfluences;
    public TierArmor tier;
    public Armor(Resistances resistances, StatusEffects statusInfluences, uint AC) : base(0) 
    {
        this.resistances = resistances;
        this.statusInfluences = statusInfluences;
        this.AC = AC;
    }
    public int TileMovementDecrease => -1 * tier switch
    {
        TierArmor.None => 0,
        TierArmor.Cloth => 0,
        TierArmor.Chainmail => 1,
        TierArmor.Plate => 2,
        TierArmor.Jouster => 3,
        _ => throw new ArgumentOutOfRangeException()
    };
}
public enum TierArmor : byte
{
    None,
    Cloth,
    Chainmail,
    Plate,
    Jouster
}