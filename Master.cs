namespace ASimpleRPG;
using System;
using ASimpleRPG.WorldData;
using OddsLibrary.IO;
using ASimpleRPG.Entities;
using System.Diagnostics;

public static class Master
{
	public static readonly Logging.Debug debug = new($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{sourceFolder}logs\\", $"{DateTime.Today}.txt");
	static readonly string saveName = "Save.sl2", sourceFolder = @"\ASimpleRPG\";
	//static FileManager saveFile = new($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\ASimpleRPG\{saveName}", true);
	public static World WorldInstance { get; private set; } = new World.Hub();
	internal static WorldObj<PlayableCharacter> player;
	static Master()
	{
		Startup.AssignTitle();
		if (Debugger.IsAttached) DemoControl();
		else
		{
			debug.Log("Launching game..", Logging.Debug.SubCategory.Startup)
			ISaveManager sv = new PlayableCharacter();
			player = sv.Load<WorldObj<PlayableCharacter>>();
		}
	}
	private static void DemoControl()
	{
		debug.LogWarning($"Using Demo Control..", Logging.Debug.SubCategory.Demo);
		player = new(new PlayableCharacter(), 0, 0, 0);
	}
	static void Main()
	{
	}
	public static event EventHandler? NewRound;
	public static void InvokeNewRound() => NewRound?.Invoke(null, EventArgs.Empty);
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