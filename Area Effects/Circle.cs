namespace ASimpleRPG;

using Logging;
using Vectoring;
using System.Collections.Generic;



// This only starts at the START of the circle, not the center. Keep this in
// mind for future projects when using vectoring.
public class Circle : AreaEffects
{
	// Thanks for https://www.csharp-console-examples.com/general/draw-a-circle-in-c-console-application/ for this amazing codebase!
	readonly double radius;
	readonly double thickness = 0.2;
	public Circle(double radius, Damage damage) : base(damage)
	{
		this.radius = radius;
		Debug.Log("Created Radial Area for Use", Debug.SubCategory.CreateObject);
	}
	public virtual AreaPackage GetAllSpots(bool isHollow)
	{
		List<Vector2> vectors = new();
		// rIn allows you to have a hole inside the circle
		// rOut adds the outside of the circle
		double rOut = radius + thickness;
		double? rIn = !isHollow ? radius - thickness : null;
		int totalLength = 0, totalHeight = 0;
		for (double y = radius, yInt = 0; y >= -radius; --y)
		{
			for (double x = -radius, xInt = 0; x < rOut; x += 0.5)
			{
				double value = x * x + y * y;
				if (rIn != null)
				{
					if (value >= rIn * rIn && value <= rOut * rOut)
						vectors.Add(new Vector2((byte)xInt, (byte)yInt));
				}
				else if (value <= rOut * rOut) // value >= rIn * rIn && 
				{
					vectors.Add(new Vector2((byte)xInt, (byte)yInt));
				}
				// This is for making sure that the length only counts the
				// first line being made
				if (y == radius) totalLength++;
				xInt++;
			}
			totalHeight++;
			yInt++;
		}
		// This should return an array with x vectors, then moves back to Y
		Debug.Log($"Returned Circle with {radius}", Debug.SubCategory.CreateObject);
		return new AreaPackage
			(
				totalLength,
				totalHeight,
				AreaPackage.GetCenterPoint(totalLength, totalHeight),
				vectors.ToArray()
			);
	}
	public override string ToString() => ToString(false);
	public string ToString(bool isHollow = false)
	{
		AreaPackage vectors = GetAllSpots(isHollow);
		return ToString(vectors);
	}

}