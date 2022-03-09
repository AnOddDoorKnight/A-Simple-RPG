namespace ASimpleRPG;

using Logging;

public class Cone : Circle
{
	public Directions currentDirection;
	public Cone(Damage damage, double radius, Directions curDirection)
		: base(radius, damage)
	{
		currentDirection = curDirection;
		Debug.Log("Created Cone AreaEffect", Debug.SubCategory.CreateObject);
	}
	public AreaPackage GetAllSpots(Directions direction)
	{
		AreaPackage reference = base.GetAllSpots(false);
		reference.Points = reference.SortPoints();
		int length, height;

		return new AreaPackage
			(
				length, 
				height, 
				AreaPackage.GetCenterPoint(length, height), 
				reference.Points
			);
	}
	public enum Directions : byte
	{
		Up,
		Left,
		Down,
		Right,
	}
}