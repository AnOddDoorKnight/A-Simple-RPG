namespace ASimpleRPG.Entities;


public abstract class Entity
{
	public abstract string? Name { get; }
	public abstract HealthData Health { get; set; }
	public abstract StatusEffects StatusEffects { get; set; }
	public abstract Resistances Resistances { get; set; }
	public int team = 0, bonusAC = 0;
	protected int baseAC = 10, armorAC = 0;
	/// <summary>Gets the <see cref="Entity"/>'s total accumulated AC.</summary>
	public int AC => baseAC + armorAC + bonusAC;
	public Entity()
	{
		Health.GetParentOfHealthData = GetThis;
	}
	public virtual void TakeDamage(Damage damage)
	{
		if (damage.AC < AC) return;
		Health.Health -= damage.value < 0 ? damage.value * -1 : Resistances.GetNewValue(damage.value, damage.damageType);
	}
	public virtual void TakeDamage(Damage[] damages)
	{
		foreach (Damage damage in damages)
			TakeDamage(damage);
	}
	private Entity GetThis() => this;
}