namespace ASimpleRPG.Entities;

using OddsLibrary.Algebra;


public class Stat
{
	public const byte hardCap = 99;
	private byte _value;
	public byte Value 
	{
		get => _value; 
		set => _value = checked((byte)Algebra.LimitValue(value, 0, hardCap)); 
	}
	public Stat(byte value) => Value = value;
	public virtual int AsVigor()
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
	public virtual int AsMind() => 1 + (7 * Value);
	public virtual (int stamina, float equipLoad) AsEndurance()
	{
		// The amount of breakpoints that lowers the effectiveness of stats
		const int staminaCap = 29, equipLoadCap = 30,
			// the actual values used for stamina
			staminaCapAffect = 2, staminaNormal = 4;
		// The Actual values used for equipLoad
		const float equipLoadNormal = 1.5f, equipLoadCapped = 1.0f;

		// Defining Values
		int stamina = 84;
		float equipLoad = 30.0f;
		
		// Assigning Stamina
		for (int i = 0; i <= Value; i++)
			stamina = stamina +
				i <= staminaCap ? staminaNormal :
				staminaCapAffect;
		// Assigning EquipLoad
		for (int i = 0; i <= Value; i++)
			equipLoad = equipLoad + 
				i <= equipLoadCap ? equipLoadNormal :
				equipLoadCapped;

		return (stamina, equipLoad);
	}
	public virtual (int strengthPower, float equipLoad) AsStrength()
	{
		const int strengthCap = 60,
			strengthNormal = 3, strengthCapped = 1;
		const float equipLoadCap = 40;

		int strengthPower = 0;
		float equipLoad = 0;

		for (int i = 0; i <= Value; i++)
			equipLoad += i <= equipLoadCap ? 0.5f : 0;
		for (int i = 0; i <= Value; i++)
			strengthPower += i <= strengthCap ? strengthNormal : strengthCapped;

		return (strengthPower, equipLoad);
	}


}
/*
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
*/