using System;
using System.Collections.Generic;
using OddsLibrary.Algebra;
namespace ASimpleRPG.Entities;
public struct Health
{
    private double _health, maxHealth;
    public bool IsDead { get; private set; }
    public double Health {
        get => _health;
        set { IsDead = Algebra.HealthManager(ref _health, maxHealth, 0); }
    }
    public Health(double health, double maxHealth = 15)
    {
        if (health <= 0 || maxHealth <= 0) 
            throw new ArgumentOutOfRangeException("Values cannot be below 0!");
        _health = health;
        this.maxHealth = maxHealth;
    }
}
public struct StatusEffects
{
    #warning TODO: #1 Add a call (Like a property) that calls when curVal is overrun by maxVal
    public StatusEffects(int? maxPoison, int? maxBleed, int? maxCursed)
    {
        maxStatus = new()
        {   
            [DamageType.Poison] = maxPoison,
            [DamageType.Bleeding] = maxBleed,
            [DamageType.Cursed] = maxCursed 
        }
        curStatus = maxStatus;
        for(int i = 0; i > curStatus.Count; i++)
            if (curStatus[(DamageType)(i + 9)] != null) curStatus = 0;
    }
    #warning BUG: #2 Compiler Errors and may not work with nullable values
    public void LowerByRound(object? sender, EventArgs e)
    {
        curStatus[DamageType.Poison] = Algebra.LimitValue(poison - 15, 0, maxPoison);
        bleed = Algebra.LimitValue(bleed - 15, 0, maxBleed);
        cursed = Algebra.LimitValue(cursed - 15, 0, maxCursed);
    }
    public delegate void DelThreshold();
    public DelThreshold? poisonThreshold, bleedThreshold, cursedThreshold;
    public Dictionary<DamageType, int?> curStatus, maxStatus;
}
// TODO: #3 Complete Summary in StatusEffects
/// <summary>
/// 
/// </summary>
public struct Resistances
{
    public float this[DamageType type] { get => Values[(int)type]; set => Values[(int)type] = value; } 
    public float[] Values = { 0, 0, 0 , 0 };
    public Resistances()
    {
        throw new NotImplementedException();
    }
    public float GetNewValue(float input, DamageType type) => 
        type == DamageType.Bludgeoning ? input - Values[3] : input - (input - Values[(DamageType)type]);
}
public struct Damage
{
    public int value;
    public DamageType damageType;
    public Damage(DamageType damageType, int value)
    {
        this.damageType = damageType;
        this.value = value;
    }
}
public enum DamageType
{
    Physical,
    Slashing,
    Thrusting,
    Bludgeoning,
    Fire,
    Magic,
    Lightning,
    Dark,
    Poison,
    Bleeding,
    Cursed,
}