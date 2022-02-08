namespace ASimpleRPG.WorldData;
public abstract partial class World
{
	public class Hub : World
	{
		public override Room[] Rooms => new Room[]
		{
			new Room(new AbstractRoomPoint[]
			{
				new AbstractRoomPoint(1, 5),
				new (-1, 5),
				new (-1, -2),
				new (1, -2),
			} ) 
			{
				canLeadTo = new RoomObj<Gate>[]
				{
					new RoomObj<Gate>(new(1), 0, -2)
				},
				worldGate = new RoomObj<WorldGate>(typeof(Forest), 0, 5)
			} },
		};
	}
}