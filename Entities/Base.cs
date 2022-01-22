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

// This is used for NPCs and the such *although it may be better to have it a separate derived class but oh well*
#warning TODO: Finish the Interact Interface
public interface IInteract
{

}
public interface IVendor
{

}