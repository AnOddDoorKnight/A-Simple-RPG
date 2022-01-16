using OddsLibrary.Algebra;
namespace ASimpleRPG.Entities;
public abstract class Entity
{
	public string? Name = null;
	public CreatureType ObjectType { get; set; }
	public Integrity Integrity;
	public Entity(CreatureType Type, Integrity? Integrity = null)
	{
		this.Integrity = Integrity ?? new Integrity(PresetHealthValues[Type]);
		Name ??= Generate.FantasyName(Type);
	}
	public static readonly Dictionary<CreatureType, short> PresetHealthValues = new()
	{
		[CreatureType.Player] = 15,
		[CreatureType.Slime] = 10,
	};
}
public struct Integrity
{
	public bool isDead = false;
	public Integrity(short initializedHealth)
	{
		MaxHealth = initializedHealth;
		_health = MaxHealth;
		isDead = false;
	}
	public Integrity(short initializedHealth, short input_Maxhealth)
	{
		MaxHealth = input_Maxhealth;
		_health = initializedHealth;
	}
	public float MaxHealth { get; set; }
	// Make checks so health doesn't go in the negatives
	private float _health;
	public float Health
	{
		get => (float)Math.Round(_health);
		set
		{
			double input = value;
			isDead = !Algebra.HealthManager(ref input, MaxHealth, 0);
			_health = (float)input;
		}
	}
}
