namespace ASimpleRPG;

using Vectoring;


public struct AreaPackage
{
	public int Length, Height;
	public Vector2[] Points;
	public Vector2 centerPoint;
	public AreaPackage(int length, int height, Vector2 center, Vector2[] Points)
	{
		Length = length;
		Height = height;
		this.Points = Points;
		centerPoint = center;
	}
	public int IndexOf(in Vector2 input)
	{
		for (int x = 0; x < Length; x++)
			if (input.X == Points[x].X && input.Y == Points[x].Y)
				return x;
		return -1;
	}
	public bool Contains(in Vector2 input) => IndexOf(input) != -1;
	public Vector2[] SortPoints()
	{
		Vector2[] newPoints = Points;
		resetToZero:
		for (int i = 0, yWeight = newPoints.Length; i < newPoints.Length; i++)
		{
			int weight = newPoints[i].X + (newPoints[i].Y * yWeight),
			comparedWeight = newPoints[i + 1].X + (newPoints[i + 1].Y * yWeight);
			if (weight > comparedWeight)
			{
				(newPoints[i + 1], newPoints[i]) = (newPoints[i], newPoints[i + 1]);
				goto resetToZero;
			}
		}
		return newPoints;
	}
	public static Vector2 GetCenterPoint(int length, int height)
		=> new ((byte)(length / 2), (byte)(height / 2));
}