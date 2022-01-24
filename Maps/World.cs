using ASimpleRPG.Entities;
using System.Collections.Generic;
namespace ASimpleRPG.WorldData;
public abstract class World
{
	public List<WorldObj<Entity>> Entities = new();
	public WorldObj<PlayableCharacter> Player = new(new PlayableCharacter(), 0, 0);
}
public class WorldObj<T> where T : class
{
	public T Value;
	public int X, Y;
	public WorldObj(T worldObj, int X, int Y)
	{
		Value = worldObj;
		this.X = X;
		this.Y = Y;
	}
}