namespace ASimpleRPG;
public struct Damage
{
    public int value, AC;
    public DamageType damageType;
    public Damage(DamageType damageType, int value, int AC)
    {
        this.damageType = damageType;
        this.value = value;
        this.AC = AC;
    }
}
public enum DamageType
{
    Physical,
    Slashing,
    Thrusting,
    Bludgeoning,
    Fire,
    Magic,
    Lightning,
    Dark,
    Poison,
    Bleeding,
    Cursed,
}