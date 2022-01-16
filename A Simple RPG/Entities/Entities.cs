namespace ASimpleRPG.Entities.Enemies;

class Enemy : Entity
{
	public Enemy(CreatureType input_enemyType, Integrity? Integrity = null) : base(input_enemyType, Integrity)
	{
		
	}
}
class Slime : Enemy
{
	public Slime() : base(CreatureType.Slime, new Integrity(Entity.PresetHealthValues[CreatureType.Slime]))
	{
		ObjectType = CreatureType.Slime;
	}
}