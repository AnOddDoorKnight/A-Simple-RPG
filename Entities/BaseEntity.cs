namespace ASimpleRPG.Entities;
public abstract class Entity
{
    public string name;
    public HealthData Health;
    public StatusEffects StatusEffects;
    public Resistances resistances;
    public int team = 0;
    public Entity(HealthData Health, StatusEffects StatusEffects, Resistances resistances)
    {
        this.Health = Health;
        this.StatusEffects = StatusEffects;
        this.resistances = resistances;
    }
}

