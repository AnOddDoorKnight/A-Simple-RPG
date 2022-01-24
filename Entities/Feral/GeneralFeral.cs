namespace ASimpleRPG.Entities;
public abstract class Feral : Entity
{
    protected static Random Random = new();
    public Feral(HealthData HealthData, StatusEffects statusEffects, Resistances resistances) : base(healthData, statusEffects, resistances)
    {

    }
    private readonly byte dice, sides, baseAC, base; 
    private DamageType damageType = DamageType.Physical;
    public virtual Damage Attack() => new(damageType, @base + (dice * Random.Next(1, sides + 1)), Random.Next(1, 21) + baseAC);;
}