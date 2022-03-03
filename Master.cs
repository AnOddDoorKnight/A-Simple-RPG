namespace ASimpleRPG;

using Vectoring;
using System;
using OddsLibrary.IO;
using Logging;


public static class Master
{
	public static WorldData.World WorldInstance { get; private set; } = new WorldData.World.Hub();
	internal static WorldObj<Entities.PlayableCharacter> player;
	public static CombatHandler? combatHandler;
	static Master()
	{
		Debug.ApplyDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{Database.Data.sourceFolder}logs\\", $"{DateTime.Today}.txt");
		Startup.AssignTitle();
		if (System.Diagnostics.Debugger.IsAttached)
		{
			Debug.LogWarning($"Using Demo Control..", Debug.SubCategory.Demo);
			player = new(new Entities.PlayableCharacter(), 0, 0, 0);
		}
		else
		{
			Debug.Log("Launching game..", Debug.SubCategory.Startup);
			player = Startup.GetSavedCharacter();
		}
	}
	static void Main()
	{
		
	}
}
public enum Stats
{
	Vigor,
	Mind,
	Endurance,
	Strength,
	Dexterity,
	Intelligence,
	Faith,
	Arcane
}