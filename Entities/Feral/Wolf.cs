namespace ASimpleRPG.Entities;
public class Wolf : Feral
{
    public Wolf() : base(new HealthData(10), new StatusEffects(80, 80, 80), new Resistances())
    {

    }
}