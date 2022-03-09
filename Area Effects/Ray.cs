namespace ASimpleRPG;

using Vectoring;
using Logging;


public class Ray : AreaEffects
{
	public Vector2 startPoint, endPoint;
	public Ray(Vector2 startPoint, Vector2 endPoint, Damage damage) : base(damage)
	{
		this.startPoint = startPoint;
		this.endPoint = endPoint;
		Debug.Log("Created Ray AreaEffect", Debug.SubCategory.CreateObject);
	}
}