namespace ASimpleRPG;
using ASimpleRPG.WorldData;
public struct AreaOfEffect
{
	public Damage damage;
	public AreaOfEffect(Damage damage)
	{
		this.damage = damage;
	}
}
public struct Ray
{
	public Vector2 startPoint, endPoint;
	public Damage damage;
	public Ray(Vector2 startPoint, Vector2 endPoint, Damage damage)
	{
		this.startPoint = startPoint;
		this.endPoint = endPoint;
		this.damage = damage;
	}
	public int FindSize() => System.Runtime.InteropServices.Marshal.SizeOf(this);
}