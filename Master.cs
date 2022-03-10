namespace ASimpleRPG;

using Vectoring;
using System;
using OddsLibrary.IO;
using Logging;
using Entities;


public static class Master
{
	public static WorldData.World WorldInstance { get; private set; } 
		= new WorldData.World.Hub();
	internal static WorldObj<PlayableCharacter> player;
	public static CombatHandler? CombatHandler { get; set; } = null;
	static Master()
	{
		Debug.ApplyDirectory
		($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}" +
		$"{Database.Data.sourceFolder}logs\\", $"{DateTime.Today}.txt");
		try
		{
			Startup.AssignTitle("A-Simple-RPG");
			if (System.Diagnostics.Debugger.IsAttached)
			{
				Debug.LogWarning($"Using Demo Control..", Debug.SubCategory.Demo);
				player = new(new PlayableCharacter("Player"), 0, 0, 0);
			}
			else
			{
				Debug.Log("Launching game..", Debug.SubCategory.Startup);
				player = Startup.GetSavedCharacter();
			}

		}
		catch (Exception ex)
		{
			Debug.LogError($"Startup Attempt Terminated with code error: {ex}", 
				Debug.SubCategory.Startup);
			throw;
		}
	}
	static void Main()
	{
		try
		{

		}
		catch (Exception ex)
		{
			Debug.LogError($"Fatal Error: {ex}");
			throw;
		}
	}
}