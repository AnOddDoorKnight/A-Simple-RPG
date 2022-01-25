using ASimpleRPG.Entities;
using System.Collections.Generic;
namespace ASimpleRPG.WorldData;
public abstract class World
{
	public List<WorldObj<Entity>> Entities = new();
	public WorldObj<PlayableCharacter> Player = new(new PlayableCharacter(), 0, 0, 0);
	public Room[] Rooms;
	public World(Room[] rooms) => Rooms = rooms;
}
public class Room
{
	
}
public struct AbstractRoomPoint
{
	public sbyte X, Y;
	public AbstractRoomPoint(sbyte X, sbyte Y) 
	{
		this.X = X;
		this.Y = Y;
	}
}
public class WorldObj<T> where T : class
{
	public T Value;
	public sbyte X, Y;
	public byte Room;
	public WorldObj(T worldObj, sbyte X, sbyte Y, byte Room)
	{
		Value = worldObj;
		this.X = X;
		this.Y = Y;
		this.Room = Room;
	}
}