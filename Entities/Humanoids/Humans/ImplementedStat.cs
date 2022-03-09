using OddsLibrary.Algebra;


namespace ASimpleRPG.Entities
{
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
		//This usually contains the HP, 483 as 10 default, 1000 of 27
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
		public virtual (float strengthPower, float equipLoad) AsStrength()
		{
			const int strengthCap = 60;
			const float
				strengthNormal = 1f, strengthCapped = 0.333f, equipLoadCap = 40;

			float strengthPower = 0, equipLoad = 0;

			for (int i = 0; i <= Value; i++)
				equipLoad += i <= equipLoadCap ? 0.5f : 0;
			for (int i = 0; i <= Value; i++)
				strengthPower += i <= strengthCap ? strengthNormal : strengthCapped;

			return (strengthPower, equipLoad);
		}
		public virtual int AsDexterity()
		{

		}
		public virtual (int intPower, int focusPoints) AsIntelligence()
		{

		}
		public virtual int AsFaith()
		{

		}
		public virtual (int itemDiscovery, int arcanePower) AsArcane()
		{

		}
	}
}
namespace ASimpleRPG
{
	public enum Stats
	{
		Vigor,
		Mind,
		Endurance,
		Strength,
		Dexterity,
		Intelligence,
		Faith,
		Arcane
	}
}