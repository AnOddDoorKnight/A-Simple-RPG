namespace ASimpleRPG.Entities;


public class Wolf : Feral
{
	public Wolf()
	{

	}
	public override string? Name => "Wolf";
	public override HealthData Health { get; set; } = new HealthData(200);
	public override StatusEffects StatusEffects { get; set; } 
		= new StatusEffects(80, 80, 80);
	public override Resistances Resistances { get; set; } 
		= new Resistances();
}