namespace ASimpleRPG.WorldData;
using System.Collections.Generic;
using System;
using ASimpleRPG.Entities;
public abstract partial class World
{	// This is stored as the whole world, or a group of rooms.
	public List<WorldObj<Entity>> otherEntities = new();
	public abstract Room[] Rooms { get; }
}
public class Room
{
	public List<RoomObj<Entity>> Entities = new(); // Creatures in room
	public AbstractRoomPoint[] roomPoints; // Parameters of the room
	public List<RoomObj<StaticObject>> objects = new(); // Objects like boxes in the room
	public RoomObj<WorldGate>? worldGate; // door to another world, if it has one
	public RoomObj<Gate>[] canLeadTo; // doors to other rooms
	public Room(AbstractRoomPoint[] roomPoints)
	{
		this.roomPoints = roomPoints;
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