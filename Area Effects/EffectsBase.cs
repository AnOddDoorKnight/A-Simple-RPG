namespace ASimpleRPG;

using Vectoring;
using Database;
using Logging;


public abstract class AreaEffects
{
	public Damage damage;
	public AreaEffects(Damage damage)
	{
		Debug.Log("Created AreaEffect for Use", Debug.SubCategory.CreateAction);
		this.damage = damage;
	}
	public static string ToString(AreaPackage areaPackage)
	{
		// This declares the string array for merging that allows you to
		// customize with the [index] function
		string[] outputs = new string[areaPackage.Height];
		for (int y = 0; y < areaPackage.Height; y++)
		{
			outputs[y] = new string(' ', areaPackage.Length);
		}
		// This should change the representation of the point that the circle 
		// can do.
		foreach (Vector2 vector in areaPackage.Points)
			outputs[vector.Y] =
				outputs[vector.Y].Remove(vector.X)
				+ Data.special
				+ outputs[vector.Y].Remove(0, vector.X);

		string output = string.Empty;
		for (int i = 0; i < outputs.Length; i++)
			output += outputs[i];
		return output;
	}
}