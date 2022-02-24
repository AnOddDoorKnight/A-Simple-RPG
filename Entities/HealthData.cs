namespace ASimpleRPG.Entities;
using System;
using OddsLibrary.Algebra;
using Logging;
public class HealthData
{
	private double _health, maxHealth;
	public bool IsDead { get; private set; } = false;
	public double Health {
		get => _health;
		set 
		{ 
			IsDead = Algebra.HealthManager(ref _health, maxHealth, 0);
			if (IsDead)
			{
				// Intentionally left null since its not supposed to do that
				Debug.Log($"{GetParentOfHealthData().name} has died");
				CallDeath();
			}
		}
	}
	public HealthData(double maxHealth)
	{
		if (maxHealth <= 0) 
			throw new ArgumentOutOfRangeException(nameof(maxHealth), maxHealth, "Values cannot be below 0!");
		this.maxHealth = maxHealth;
		_health = maxHealth;
	}
	public HealthData(double health, double maxHealth)
	{
		if (health <= 0 || maxHealth <= 0) 
			throw new ArgumentOutOfRangeException(nameof(maxHealth), maxHealth, "Values cannot be below 0!");
		_health = health;
		this.maxHealth = maxHealth;
	}
	public delegate Entity DelGetOwner();
	public DelGetOwner? GetParentOfHealthData;
	public CombatHandler.DelDeclareDeath? declareDeath;
	public void CallDeath() => declareDeath?.Invoke(GetParentOfHealthData?.Invoke());
}