using ASimpleRPG.Entities;
using System.Collections.Generic;
namespace ASimpleRPG.WorldData;
public abstract class World
{
	public List<Entity> Entities = new();
	public PlayableCharacter Player = new();
}