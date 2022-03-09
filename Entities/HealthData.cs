namespace ASimpleRPG.Entities;

using System;
using OddsLibrary.Algebra;
using Logging;


/// <summary>Storage for health</summary>
public class HealthData
{
	private int _health, maxHealth;
	public bool IsDead { get; private set; } = false;
	public int Health {
		get => _health;
		set 
		{
			double advHealth = _health;
			IsDead = Algebra.HealthManager(ref advHealth, maxHealth, 0);
			_health = (int)advHealth;
			if (IsDead)
			{
				// Intentionally left null since its not supposed to do that
				Debug.Log($"{GetParentOfHealthData!.Invoke().Name} has died");
				CallDeath();
			}
		}
	}
	public HealthData(int maxHealth)
	{
		if (maxHealth <= 0) 
			throw new ArgumentOutOfRangeException
				(nameof(maxHealth), maxHealth, "Values cannot be below 0!");
		this.maxHealth = maxHealth;
		_health = maxHealth;
	}
	public HealthData(int health, int maxHealth) : this(maxHealth)
	{
		if (health <= 0) 
			throw new ArgumentOutOfRangeException
				(nameof(health), health, "Values cannot be below 0!");
		_health = health;
	}
	public delegate Entity DelGetOwner();
	public DelGetOwner? GetParentOfHealthData;
	public CombatHandler.DelDeclareDeath? declareDeath;
	public void CallDeath() => declareDeath?.Invoke(GetParentOfHealthData?.Invoke());
}