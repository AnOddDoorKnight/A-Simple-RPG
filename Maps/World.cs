using ASimpleRPG.Entities;
using System.Collections.Generic;
namespace ASimpleRPG.WorldData;
public abstract partial class World
{
	public List<WorldObj<Entity>> otherEntities = new();
	public abstract Room[] Rooms { get; }
	public byte currentRoom;
}
public class Room
{
	public List<RoomObj<Entity>> Entities = new();
	public AbstractRoomPoint[] roomPoints;
	public Room(AbstractRoomPoint[] roomPoints) => this.roomPoints = roomPoints;
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