namespace ASimpleRPG.WorldData;
public abstract partial class World
{
	
	public class Hub : World
	{
		public override Room[] Rooms => new Room[]
		{
			new Room(new AbstractRoomPoint[]
			{
				new AbstractRoomPoint(1, 2),
				new (-1, 2),
				new (-1, -2),
				new (1, -2),
			} ) { randomData = new() { } },
		};
	}
}