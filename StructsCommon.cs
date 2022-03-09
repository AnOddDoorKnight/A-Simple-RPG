namespace ASimpleRPG;


public struct StatDataPackage
{
    public Stats type;
    public sbyte calculatedModifier;
    public StatDataPackage(Stats type, sbyte calculatedModifier)
	{
        this.type = type;
        this.calculatedModifier = calculatedModifier;
	}
}