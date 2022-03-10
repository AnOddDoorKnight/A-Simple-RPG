namespace ASimpleRPG.Entities;

using StackOverflow;


public abstract class Entity
{
	public abstract string? Name { get; }
	public abstract HealthData Health { get; set; }
	public bool isDead = false;
	public abstract StatusEffects StatusEffects { get; set; }
	public abstract Resistances Resistances { get; set; }
	public int team = 0, bonusAC = 0;
	protected int armorAC = 0;
	protected readonly static int baseAC = 10;
	/// <summary>Gets the <see cref="Entity"/>'s total accumulated AC.</summary>
	public int AC => baseAC + armorAC + bonusAC;
	public Entity()
	{
		// This SHOULD create a reference, hopefully
		Health.baseEntity = 
			new Ref<Entity>(() => this, johnny => { johnny = this; });
		Health.GetParentOfHealthData = GetThis;
	}
	public virtual void TakeDamage(Damage damage)
	{
		if (damage.AC < AC) return;
		Health.TakeDamage(Resistances.GetNewValue(damage.value, damage.damageType));
	}
	public virtual void TakeDamage(Damage[] damages)
	{
		foreach (Damage damage in damages)
			TakeDamage(damage);
	}
	private Entity GetThis() => this;
}