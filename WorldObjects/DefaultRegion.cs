namespace ASimpleRPG.WorldData;

using Vectoring;


public abstract partial class World
{
	public class Hub : World
	{
		public override Room[] Rooms => new Room[]
		{
			new Room(new Vector2[] {
				new Vector2(2, 5),
				new (0, 5),
				new (0, 0),
				new (2, 0),
			},
			new RoomObj<Gate>[]
			{
				new RoomObj<Gate>(new(1), 1, 0)
			} )
			{
				worldGate = new RoomObj<WorldGate>(new WorldGate(typeof(Forest), 0), 1, 5)
			},
		};
	}
} 