namespace ASimpleRPG.WorldData;
public class RoomObj<T> where T : class
{
	public T Value;
	public sbyte X, Y;
	public RoomObj(T worldObj, sbyte X, sbyte Y)
	{
		Value = worldObj;
		this.X = X;
		this.Y = Y;
	}
}
public class WorldObj<T> : RoomObj<T> where T : class
{
	public byte Room;
	public WorldObj(T worldObj, sbyte X, sbyte Y, byte Room) : base(worldObj, X, Y)
	{
		this.Room = Room;
	}
	public RoomObj<T> GetRoomObj() => this;
}