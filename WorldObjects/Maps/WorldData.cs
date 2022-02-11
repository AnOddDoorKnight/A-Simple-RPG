namespace ASimpleRPG.WorldData;
using System;
using System.Collections.Generic;
using System.Linq;
using ASimpleRPG.Entities;
public abstract partial class World
{	// This is stored as the whole world, or a group of rooms.
	public List<WorldObj<Entity>> otherEntities = new();
	public abstract Room[] Rooms { get; }
}
public class Room
{
	public Vector2[] roomPoints; // Parameters of the room
	public RoomObj<Entity>[]? Entities; // Creatures in room
	public RoomObj<StaticObject>[]? objects; // Objects like boxes in the room
	public RoomObj<WorldGate>? worldGate; // door to another world, if it has one
	public RoomObj<Gate>[] canLeadTo; // doors to other rooms
	public Room(Vector2[] roomPoints, RoomObj<Gate>[] gates)
	{
		this.roomPoints = roomPoints;
		canLeadTo = gates;
	}
	//public void Update() { }
	public override string ToString()
	{
		// We can specify what chars to replace by providing vector2 coordinates
		string output = "";
		char[,] outputArray;
		List<byte> heights = new(), lengths = new();
		foreach (Vector2 roomPoint in roomPoints)
		{
			// This calculates the corners for it to be rendered, specifically
			// The topLeft (height = highest, width = smallest) and the bottomRight
			heights.Add(roomPoint.Y);
			lengths.Add(roomPoint.X);
		}
		heights.Sort();
		lengths.Sort();
		byte height = (byte)(heights[^1] - heights[0]), length = (byte)(lengths[0] - lengths[^1]);
		// We add the chars here
		outputArray = new char[height, length];
		for (int i = 0; i < height; i++) 
			for (int ii = 0; ii < length; ii++) 
				outputArray[i, ii] = Icons.Data.emptySpace;
		Vector2[] AdjustedRoomPoints = new Vector2[roomPoints.Length];
		for (int i = 0; i < roomPoints.Length; i++)
			AdjustedRoomPoints[i] = new Vector2((byte)(roomPoints[i].X - heights[0]), (byte)(roomPoints[i].Y - heights[0]));
		// Now, lets take between the two points of vector2s
		for (int i = 0; i <= roomPoints.Length; i++)
		{	
			Vector2 roomPoint = roomPoints[i], 
				secondRoomPoint = roomPoints[i != roomPoints.Length ? i + 1 : 0];
			outputArray[roomPoint.X, roomPoint.Y] = Icons.Data.wall;
			// Take the value of both X and get the difference between them
			// Then, divide it by how many squares there are and round
			byte[] lengthsBetweenThemPerPoint = new byte[(byte)Math.Round((double)(roomPoint.X - secondRoomPoint.X))];
			for (int ii = 0; lengthsBetweenThemPerPoint.Length > 0; ii++)
			{	// 0 will be first, = to is to second

			}
		}
		//
		List<List<Vector2>> blocks = new();
		for (int i = 0; i < height; i++) blocks.Add(new List<Vector2>());
		for (int i = 0; i < roomPoints.Length; i++) ;


		// Here we actually render it!
		for (int i = 0; i < heights[^1]; i++)
		{
			for (int ii = 0; ii < lengths[^1]; ii++)
				output += Icons.Data.emptySpace;
			output += "\n";
		} 
		return output;
	}
	public string[] ToArray() => ToString().Split('\n');
	public List<string> ToList() => ToArray().ToList();
	public HashSet<string> ToHashSet() => ToArray().ToHashSet();
}
public struct Vector2
{
	public byte X, Y;
	public Vector2(byte X, byte Y)
	{
		this.X = X;
		this.Y = Y;
	}
}