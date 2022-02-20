namespace ASimpleRPG.WorldData;
public class RoomObj<T> where T : class
{
	public T Value;
	public byte X, Y;
	public RoomObj(T worldObj, byte X, byte Y)
	{
		Value = worldObj;
		this.X = X;
		this.Y = Y;
		Master.debug.Log($"Object Created in room: ({X}, {Y})", Logging.Debug.SubCategory.CreateObject);
	}
}
public class WorldObj<T> : RoomObj<T> where T : class
{
	public byte Room;
	public WorldObj(T worldObj, byte X, byte Y, byte Room) : base(worldObj, X, Y)
	{
		this.Room = Room;
	}
}