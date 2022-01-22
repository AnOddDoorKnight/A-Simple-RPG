namespace ASimpleRPG.Entities;
public class PlayableCharacter : Human, ISaveManager
{


	public PlayableCharacter()
	{
		
	}

	void ISaveManager.Load()
	{
		throw new System.NotImplementedException();
	}
	void ISaveManager.Save()
	{
		throw new System.NotImplementedException();
	}
}