using System;
using OddsLibrary.Algebra;
namespace ASimpleRPG.Entities;
public class HealthData
{
	private double _health, maxHealth;
	public bool IsDead { get; private set; } = false;
	public double Health {
		get => _health;
		set { IsDead = Algebra.HealthManager(ref _health, maxHealth, 0); }
	}
	private HealthData(DelGetOwner? getOwner)
	{
		GetOwner = getOwner;
	}
	public HealthData(double maxHealth, DelGetOwner? getOwner = null) : this(getOwner)
	{
		if (maxHealth <= 0) 
			throw new ArgumentOutOfRangeException(nameof(maxHealth), maxHealth, "Values cannot be below 0!");
		this.maxHealth = maxHealth;
		_health = maxHealth;
	}
	public HealthData(double health, double maxHealth, DelGetOwner? getOwner = null) : this(getOwner)
	{
		if (health <= 0 || maxHealth <= 0) 
			throw new ArgumentOutOfRangeException(nameof(maxHealth), maxHealth, "Values cannot be below 0!");
		_health = health;
		this.maxHealth = maxHealth;
	}
	public delegate Entity DelGetOwner();
	public DelGetOwner? GetOwner;
	public void CallDeath() => Master.InvokeDeclareDeath(GetOwner?.Invoke());
}