using ASimpleRPG.Entities;
using ASimpleRPG.WorldData;
using System.Collections.Generic;
namespace ASimpleRPG.WorldData;
public class World
{
	public Region region;
	public List<Entity> entities = new();
	public PlayableCharacter player = new();
}