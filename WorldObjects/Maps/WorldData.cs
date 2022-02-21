namespace ASimpleRPG.WorldData;
using static Database.Data;
using System;
using System.Collections.Generic;
using ASimpleRPG.Entities;
/// <summary>
/// A container for array of <see cref="Room"/>, 
/// </summary>
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
	public override string ToString()
	{
		string[] outputArray = ToArray();
		string output = "";
		foreach (string i in outputArray)
			output += $"{i}\n";
		return output;
	}
	public char[,] ToCharArray()
	{
		// Finding the highest value here:
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
		// The declared variable to return
		char[,] outputArray = new char[heights[^1], lengths[^1]];
		// first, we make all chars set to emptySpace
		for (int i = 0; i < outputArray.GetLength(0); i++)
			for (int ii = 0; ii < outputArray.GetLength(1); ii++)
				outputArray[i, ii] = emptySpace;
		// Second, we add walls to the vectors themselves; as a corner
		foreach (Vector2 roomPoint in roomPoints)
			outputArray[roomPoint.Y, roomPoint.X] = corner;
		// Third, we find the lengths between them
		for (int i = 0; i < roomPoints.Length; i++)
		{
			// Take the X and find the length between them
			// X and X++
			// Divide it by the amount of squares between them
			// Round it when done after that
			Vector2 _1 = roomPoints[i], _2 = roomPoints[i + 1];
			OddsLibrary.Vector.VectorDynamic 
				Vect1 = new(new float[] { _1.X, _1.Y }), 
				Vect2 = new(new float[] { _2.X, _2.Y });
			int smallLength = Vect1[0] > Vect2[0] ? (int)Vect2[0] : (int)Vect1[0], 
				smallHeight = (int)Vect2.DistanceBetweenInArray(Vect1)[1],
				smallest = Vect1[1] > Vect2[1] ? (int)Vect2[1] : (int)Vect1[1];
			// 0-1 each square/y / (divide it by the size of length
			for (int ii = 1; ii < smallHeight; ii++)
			{
				#warning TODO: Test this!
				outputArray[ii + smallLength - 1, smallHeight != 0 ? (byte)Math.Round((double)((ii / smallHeight) + smallest)) : smallest] = wall; // X length here
			}
		}
		// Now, we turn it into a string array!
		return outputArray;
	}
	public string[] ToArray()
	{
		char[,] outputArray = ToCharArray();
		string[] output = new string[outputArray.GetLength(0)];
		for (int i = 0; i < outputArray.GetLength(0); i++)
		{
			output[i] = string.Empty;
			for (int ii = 0; ii <= outputArray.GetLength(1); ii++)
				output[i] += outputArray[i, ii];
			output[i] += '\n';
		}
		return output;
	}
}
public struct Vector2
{
	public byte X, Y;
	public Vector2(byte X, byte Y)
	{
		this.X = X;
		this.Y = Y;
	}
	public static void GetVector()
	{
		System.Diagnostics.Process.Start("https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpreview.redd.it%2Fo0uoqmgoqw541.jpg%3Fauto%3Dwebp%26s%3D9c7db02153d0ddfce7b49c6f84bc9dbbbc346c35&f=1&nofb=1");
		Console.WriteLine("Haha you just got vectored");
	}
}