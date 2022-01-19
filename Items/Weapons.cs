namespace ASimpleRPG.Items;
public sealed class SavingGrace : Weapon
{
    
}
public sealed class HeavyBranch : Weapon
{

}
public abstract class Weapon : Item
{
    public Weapon()
    {

    }
    public virtual Damage Attack()
    {
        
    }
}