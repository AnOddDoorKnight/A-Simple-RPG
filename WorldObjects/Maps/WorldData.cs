namespace ASimpleRPG.WorldData;
using System.Collections.Generic;
using System;
using ASimpleRPG.Entities;
public abstract partial class World
{
	public List<WorldObj<Entity>> otherEntities = new();
	public abstract Room[] Rooms { get; }
	public byte currentRoom;
}
public class Room<T2>
{
	public List<RoomObj<Entity>> Entities = new();
	public AbstractRoomPoint[] roomPoints;
	public List<dynamic> randomData = new();
	public WorldGate<T2>? gate;
	public Room(AbstractRoomPoint[] roomPoints)
	{
		this.roomPoints = roomPoints;
	}
}
public class WorldGate<T2> : RoomObj<WorldGate<T2>> where T2 : World
{
	public new Type Value;
	public WorldGate(sbyte X, sbyte Y) : base(null, X, Y)
	{
		Value = typeof(T2);
	}
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