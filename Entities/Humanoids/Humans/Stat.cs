namespace ASimpleRPG.Entities;
using OddsLibrary.Algebra;
using System.Collections.Generic;
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
public abstract class Stat<T> where T : struct
{
	public const byte hardCap = 99;
	private byte _value;
	public byte Value { get => _value; set => _value = checked((byte)Algebra.LimitValue(value, 0, hardCap)); }
	public Stat(byte Value)
	{
		this.Value = Value;
	}
	public abstract T GetCalculatedValue();
	public Stat[] GetAll(byte vigor, byte mind, byte endurance, byte strength, byte dexterity, byte intelligence, byte faith, byte arcane)
	{
		return new Stat[] { new Vigor(vigor), new Mind(mind), new Endurance(endurance), new }
	}
}
public sealed class Vigor : Stat<int>
{
	public Vigor(byte Value) : base(Value) { }
	public override int GetCalculatedValue()
	{
		const int buffedCap = 21, standardCap = 36, softCapCap = 72, buffed = 47, standard = 34, softCap = 14, hardCap = 4;
		int output = 13;
		for (int i = 0; i <= Value; i++)
			output = output + 
				i <= buffedCap ? buffed : 
				i <= standardCap ? standard : 
				i <= softCapCap ? softCap : 
				hardCap;
		return output;
	}
}
public sealed class Mind : Stat<int>
{
	public Mind(byte Value) : base(Value) { }
	public override int GetCalculatedValue()
	{
		int output = 1;
		for (int i = 0; output <= Value; i++)
			output += 7;
		return output;
	}
}
public sealed class Endurance : Stat<EndurancePackage>
{
	public Endurance(byte Value) : base(Value) { }
	public override EndurancePackage GetCalculatedValue()
	{
		EndurancePackage package = new() { endurance = 102, equipLoad = 40.0f };
		const int buffedCap = 32;
		for (int i = 0; i <= buffedCap; i++)
		{
			package.equipLoad += buffedCap <= i ? 1.0f : ;
			package.endurance += buffedCap <= i ? 4 : ;
		}
		return package;
	}
}
public struct EndurancePackage
{
	public int endurance; public float equipLoad;
}
public sealed class Strength : Stat<int>
{
	
}
public sealed class Dexterity : Stat<int>
{

}
public sealed class Intelligence : Stat<int>
{

}
public sealed class Faith : Stat<int>
{

}
public sealed class Arcane : Stat<ArcanePackage>
{

}
public struct ArcanePackage
{

}