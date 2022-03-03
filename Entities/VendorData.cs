namespace ASimpleRPG.Entities;

using Items;


// This is used for NPCs and the such *although it may be better to have it a separate derived class but oh well*
#warning TODO: #5 Finish the Interact Interface
public interface IInteract
{

}
public interface IVendor
{
	Item[] PurchasableItems { get; }
}