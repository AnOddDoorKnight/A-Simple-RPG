using ASimpleRPG.Items;
using System.Collections.Generic;
using System;
using OddsLibrary.Algebra;
namespace ASimpleRPG.Entities;
public class Human : Entity
{
	private Weapon? _weapon;
	public Weapon EquippedWeapon { get => _weapon ?? new Fists(); set => _weapon; }
	public Armor armor;
	public Dictionary<Stats, >
    public Human() : base(new HealthData(15), new StatusEffects(100, 100, 100), new Resistances())
    {

    }

    
}
public struct Stat
{
	public const byte softCap = 18, @base = 10, hardCap = 99;
	private byte _value = 0;
	public byte Value { get => _value; set => _value = checked((byte)Algebra.LimitValue(value, 0, hardCap)); }
	public Stat(byte Value = 0) => this.Value = Value;
	// If value is greater than 18, then it will do the false statement and will always return +4 if it is 18, then halves the effectiveness on the future amounts.
	// Use this to determine health, damage and such.
	public sbyte Modifier() => Value > softCap ? (sbyte)(4 + Math.Truncate((double)(Value - softCap) / 4)) : (sbyte)Math.Truncate((double)(Value - @base) / 2);
}