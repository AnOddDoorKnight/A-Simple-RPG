using System.Collections.Generic;
using ASimpleRPG.Objects;
using OddsLibrary.Algebra;

namespace ASimpleRPG.Entities.Char;

public class Character : Entity
{
	#region Statistics & Specifications
	public new const CreatureType ObjectType = CreatureType.Player;
	public Class? Class { get; set; } = null;
	public Level Level;
	public Stats Stats;
	#endregion
	private Weapon? currentWeapon;
	public Weapon CurrentWeapon => currentWeapon ?? new Fists();
	public List<Item> inventory = new();
	public Character(Stats? stats = null) : base(ObjectType, new Integrity((byte)Stats.GetStartHealth(0, 1, 10)))
	{
		Stats = stats ?? new Stats();
		Level = new Level();
	}
}
public struct Level
{
	private float func_experience = 0;
	public byte CurrentLevel { get; set; } = 1;
	private readonly byte maxLevel;
	public Level(float startingXp, byte maxLevel = 30)
	{
		this.maxLevel = maxLevel;
		Experience = startingXp;
	}
	public Level(byte maxLevel = 30) => this.maxLevel = maxLevel;
	// Linear Progression aka 1 = 10 xp, 2 = 10 + 5 xp, 3 = 10 + 10 xp, 4 = 10 + 15 xp
	static ushort GetLevelRequirement(byte desiredLevel) => (ushort)(10 + ((desiredLevel * 5) - 5));
	public float Experience
	{
		get => func_experience;
		set
		{
			func_experience = value;
			Console.WriteLine($"You gained {func_experience - value} xp, you now have {func_experience} xp.");
			// Adds levels if level is less than maxLevel, and if there are more points than level requirement
			while (Experience >= GetLevelRequirement((byte)(CurrentLevel + 1)) && CurrentLevel < maxLevel)
			{
				CurrentLevel++;
				func_experience -= GetLevelRequirement(CurrentLevel);
			}
		}
	}
}
public sealed class StoryData
{

}
public struct Stats
{
	public Dictionary<StatType, Stat> Statistics = new()
	{
		[StatType.Strength] = new Stat(10),
		[StatType.Dexterity] = new Stat(10),
		[StatType.Constitution] = new Stat(10),
		[StatType.Intelligence] = new Stat(10),
		[StatType.Wisdom] = new Stat(10),
		[StatType.Charisma] = new Stat(10),
	};
	
	public Stats() { }
	public Stats(byte in_Str = 10, byte in_Dex = 10, byte in_Con = 10, byte in_Int = 10, byte in_Wis = 10, byte in_Chr = 10)
	{
		Statistics[StatType.Strength] = new(in_Str);
		Statistics[StatType.Dexterity] = new(in_Dex);
		Statistics[StatType.Constitution] = new(in_Con);
		Statistics[StatType.Intelligence] = new(in_Int);
		Statistics[StatType.Wisdom] = new(in_Wis);
		Statistics[StatType.Charisma] = new(in_Chr);
	}
	public static float GetStartHealth(byte Modifier, byte level, byte level1HP) => level * (level1HP + Modifier);
	public enum StatType
	{
		Strength,
		Dexterity,
		Constitution,
		Intelligence,
		Wisdom,
		Charisma
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
}
public enum Class : byte
{
	All,
	Knight
}
