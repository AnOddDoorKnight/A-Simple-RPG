namespace ASimpleRPG.Entities;
using ASimpleRPG.WorldData;
using System;
public class PlayableCharacter : Human, ISaveManager
{


	public PlayableCharacter()
	{
		team = 1;
	}

	public string SaveFileLocation => "";
	public T Load<T>()
	{
		if (typeof(T) != typeof(WorldObj<PlayableCharacter>)) 
			throw new ArgumentException($"{nameof(T)} is not a valid type for loading! use {nameof(PlayableCharacter)}");

		throw new NotImplementedException();
	}
	public void Save<T>(T inheritedClass)
	{
		throw new NotImplementedException();
	}
}