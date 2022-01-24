using System;
namespace ASimpleRPG.Entities;
public class PlayableCharacter : Human, ISaveManager
{


	public PlayableCharacter()
	{
		team = 1;
	}
	dynamic ISaveManager.Load()
	{
		return new PlayableCharacter();
		throw new NotImplementedException();
	}
	void ISaveManager.Save(dynamic inheritedClass)
	{
		if (inheritedClass != typeof(PlayableCharacter)) throw new InvalidOperationException();
		throw new NotImplementedException();
	}
}