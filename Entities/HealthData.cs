using System;
using OddsLibrary.Algebra;
namespace ASimpleRPG.Entities;
public struct HealthData
{
    private double _health, maxHealth;
    public bool IsDead { get; private set; } = false;
    public double Health {
        get => _health;
        set { IsDead = Algebra.HealthManager(ref _health, maxHealth, 0); }
    }
    public HealthData(double maxHealth)
	{
        if (maxHealth <= 0) 
            throw new ArgumentOutOfRangeException("Values cannot be below 0!");
        this.maxHealth = maxHealth;
        _health = maxHealth;
	}
    public HealthData(double health, double maxHealth)
    {
        if (health <= 0 || maxHealth <= 0) 
            throw new ArgumentOutOfRangeException("Values cannot be below 0!");
        _health = health;
        this.maxHealth = maxHealth;
    }
}