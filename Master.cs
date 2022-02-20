namespace ASimpleRPG;
using System;
using System.IO;
using ASimpleRPG.WorldData;
using OddsLibrary.IO;
using ASimpleRPG.Entities;
using System.Diagnostics;
using ASimpleRPG.FileLocations;
public static class Master
{
	public static readonly Logging.Debug debug = 
		new($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{Data.sourceFolder}logs\\", $"{DateTime.Today}.txt");
	//static FileManager saveFile = new($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\ASimpleRPG\{saveName}", true);
	public static World WorldInstance { get; private set; } = new World.Hub();
	internal static WorldObj<PlayableCharacter> player;
	static Master()
	{
		Startup.AssignTitle();
		if (Debugger.IsAttached)
		{
			debug.LogWarning($"Using Demo Control..", Logging.Debug.SubCategory.Demo);
			player = new(new PlayableCharacter(), 0, 0, 0);
		}
		else
		{
			debug.Log("Launching game..", Logging.Debug.SubCategory.Startup);
			player = Startup.GetSavedCharacter();
		}
	}
	static void Main()
	{
		
	}
	public static event EventHandler? NewRound;
	public static void InvokeNewRound() => NewRound?.Invoke(null, EventArgs.Empty);
	public static event EventHandler? DeclareDeath;
	public static void InvokeDeclareDeath(object? sender) => NewRound?.Invoke(sender, EventArgs.Empty);
}
public enum Stats
{
	Strength,
	Dexterity,
	Constitution,
	Wisdom,
	Intelligence,
	Charisma
}