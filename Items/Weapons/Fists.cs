namespace ASimpleRPG.Items;
public sealed class Fists : Weapon
{
    public Fists(Modifier damageModifier, Modifier ACModifier) : base(1, 4, damageModifier, ACModifier, 0)
    {
        finesse = true;
        agile = true;
        name = "Fists";
        description = "Hands given form to be best described as tiny flesh hammers.\n\nRepresents the physical skill the user has obtained";
        damageType = DamageType.Bludgeoning;
    }
}