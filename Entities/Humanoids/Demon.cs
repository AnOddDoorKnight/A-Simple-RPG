namespace ASimpleRPG.Entities;


/// <summary>Also known as a demon</summary>
public class Javascript : Human
{
	public override string Name => "Javascript";
	public override HealthData Health { get; set; }
	public Javascript()
	{
		Health = new HealthData(50);
	}
}