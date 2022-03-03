namespace ASimpleRPG.Entities;


/// <summary>Also known as a demon</summary>
public class Javascript : Human
{
	public Javascript() : base(new HealthData(50), null, null)
	{
		name = "Demon";
	}
}