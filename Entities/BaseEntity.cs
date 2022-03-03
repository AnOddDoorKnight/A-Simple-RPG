namespace ASimpleRPG.Entities;
public abstract class Entity
{
	public string? name;
	public HealthData Health;
	public StatusEffects StatusEffects;
	public Resistances resistances;
	public int team = 0, bonusAC = 0;
	protected int baseAC = 10, armorAC = 0;
	/// <summary>Gets the <see cref="Entity"/>'s total accumulated AC.</summary>
	public int AC => baseAC + armorAC + bonusAC;
	public Entity(HealthData Health, StatusEffects StatusEffects, Resistances resistances)
	{
		Health.GetParentOfHealthData = GetThis;
		this.Health = Health;
		this.StatusEffects = StatusEffects;
		this.resistances = resistances;
	}
	public virtual void TakeDamage(Damage damage)
	{
		if (damage.AC < AC) return;
		Health.Health -= damage.value < 0 ? damage.value * -1 : resistances.GetNewValue(damage.value, damage.damageType);
	}
	public virtual void TakeDamage(Damage[] damages)
	{
		foreach (Damage damage in damages)
			TakeDamage(damage);
	}
	private Entity GetThis() => this;
}

