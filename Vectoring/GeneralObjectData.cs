namespace ASimpleRPG.Vectoring;

using Logging;



public class RoomObj<T> where T : class
{
	public T Value;
	public int X, Y;
	public RoomObj(T worldObj, int X, int Y)
	{
		Value = worldObj;
		this.X = X;
		this.Y = Y;
		Debug.Log($"Object Created in room: ({X}, {Y})", 
			Debug.SubCategory.CreateObject);
	}
	public Vector2 ToVector2() => new(X, Y);
}


public class WorldObj<T> : RoomObj<T> where T : class
{
	public byte Room;
	public WorldObj(T worldObj, int X, int Y, byte Room) : base(worldObj, X, Y)
	{
		this.Room = Room;
	}
}