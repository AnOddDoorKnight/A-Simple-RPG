namespace ASimpleRPG.Entities;
public abstract class Entity
{
    public string name;
    public Health Health;
    public StatusEffects StatusEffects;
    public Resistances resistances;
    public Entity(Health Health, StatusEffects StatusEffects)
    {
        this.Health = health;
        this.StatusEffects = StatusEffects;
    }
}