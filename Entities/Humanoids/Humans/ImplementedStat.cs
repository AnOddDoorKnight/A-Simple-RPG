namespace ASimpleRPG.Entities;

using OddsLibrary.Algebra;


/// <summary>
///   <para>
/// A statistic that stores values for things like <see cref="ASimpleRPG.Modifier" />.
/// </para>
///   <para>
///     <font color="#333333">Not to be confused with <see cref="Modifier" /></font>
///   </para>
/// </summary>
/// <seealso cref="Modifier" />
public abstract class BaseStat
{

}
public abstract class ImplementedStat<T> where T : struct
{
	public const byte hardCap = 99;
	private byte _value;
	public byte Value { get => _value; set => _value = checked((byte)Algebra.LimitValue(value, 0, hardCap)); }
	public ImplementedStat(byte Value)
	{
		this.Value = Value;
	}
	public abstract T GetCalculatedValue();
	public ImplementedStat<object>[] GetAll(byte vigor, byte mind, byte endurance,
		byte strength, byte dexterity, byte intelligence, byte faith, byte arcane)
	{
		return new ImplementedStat<object>[] { new Vigor(vigor), new Mind(mind), new Endurance(endurance), new }
	}
}



public sealed class Vigor : ImplementedStat<int>
{
	public Vigor(byte Value) : base(Value) { }
	public override int GetCalculatedValue()
	{
		// These are the caps of the values that are implemented with
		const int buffedCap = 21, standardCap = 36, softCapCap = 72, 
		// The actual values that are multiplied with
			buffed = 47, standard = 34, softCap = 14, hardCap = 4;
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
public sealed class Mind : ImplementedStat<int>
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
public sealed class Endurance : ImplementedStat<EndurancePackage>
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
public sealed class Strength : ImplementedStat<int>
{
	
}
public sealed class Dexterity : ImplementedStat<int>
{

}
public sealed class Intelligence : ImplementedStat<int>
{

}
public sealed class Faith : ImplementedStat<int>
{

}
public sealed class Arcane : ImplementedStat<ArcanePackage>
{

}
public struct ArcanePackage
{

}