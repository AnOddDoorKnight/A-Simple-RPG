namespace ASimpleRPG.WorldData;
public class Crate : StaticObject
{
    public override byte X => 1;
    public override byte Y => 1;
    public Crate(Quality quality) : base($"Crate", quality)
    {
        
    }   
}