namespace ASimpleRPG;

using Vectoring;
using System.Collections.Generic;


public class Block : AreaEffects
{
	public byte length, height;
	public Block(Damage damage, byte length, byte height) : base(damage)
	{
		this.length = length;
		this.height = height;
	}
	public AreaPackage GetAllSpots(bool isHollow)
	{
		List<Vector2> points = new();
		if (isHollow)
		{
			for (byte i = 0; i < height; i++)
				for (byte ii = 0; ii < length; ii++)
				{
					if (i == 0 || i == height - 1)
						points.Add(new Vector2(i, ii));
					else if (ii == 0 || ii == height - 1)
						points.Add(new Vector2(i, ii));
				}
			return new AreaPackage();
		}

		// These are assigning a solid rectangle via VectorPoints.
		for (byte i = 0; i < height; i++)
			for (byte ii = 0; ii < length; ii++)
				points.Add(new Vector2(i, ii));
		return new AreaPackage
			(
				length, 
				height, 
				AreaPackage.GetCenterPoint(length, height), 
				points.ToArray()
			);
	}
}