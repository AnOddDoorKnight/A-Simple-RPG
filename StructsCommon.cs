namespace ASimpleRPG;
public struct Modifier
{
    public Stats type;
    public sbyte calculatedModifier;
    public Modifier(Stats type, sbyte calculatedModifier)
	{
        this.type = type;
        this.calculatedModifier = calculatedModifier;
	}
}