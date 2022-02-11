namespace ASimpleRPG.WorldData;
public abstract partial class World
{
	public class Hub : World
	{
		public override Room[] Rooms => new Room[]
		{
			new Room(new Vector2[]
			{
				new Vector2(2, 5),
				new (0, 5),
				new (0, 2),
				new (2, 2),
			} )
			{
				canLeadTo = new RoomObj<Gate>[]
				{
					new RoomObj<Gate>(new(1), 0, -2)
				},
				worldGate = new RoomObj<WorldGate>(new WorldGate(typeof(Forest), 0), 0, 5)
			} },
		};
	}
} 