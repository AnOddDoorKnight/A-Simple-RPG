namespace ASimpleRPG.Entities;
using OddsLibrary.Algebra;
using System;
/// <summary>
///   <para>
/// A statistic that stores values for things like <see cref="ASimpleRPG.Modifier" />.
/// </para>
///   <para>
///     <font color="#333333">Not to be confused with <see cref="Modifier" /></font>
///   </para>
/// </summary>
/// <seealso cref="Modifier" />
public class Stat
{
	public const byte softCap = 18, @base = 10, hardCap = 99;
	private byte _value = 0;
	public byte Value { get => _value; set => _value = checked((byte)Algebra.LimitValue(value, 0, hardCap)); }
	public Stat(byte Value = 0) => this.Value = Value;
	// If value is greater than 18, then it will do the false statement and will always return +4 if it is 18, then halves the effectiveness on the future amounts.
	// Use this to determine health, damage and such.
	public sbyte Modifier => Value > softCap ? (sbyte)(4 + Math.Truncate((double)(Value - softCap) / 4)) : (sbyte)Math.Truncate((double)(Value - @base) / 2);
}