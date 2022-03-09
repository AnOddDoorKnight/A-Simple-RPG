namespace ASimpleRPG.WorldData;

using Vectoring;
using System;


public abstract partial class World
{
	public class Hub : World
	{
		public override Room[] Rooms => new Room[]
		{
			new Room(
				new Vector2[] 
				{	new (2, 5),
					new (0, 5),
					new (0, 0),
					new (2, 0)
				},
				Array.Empty<RoomObj<Gate>>()
				)
		};
	}
}