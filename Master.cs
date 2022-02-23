global using static System.Console;
global using static System.Math;
global using ASimpleRPG.Vectoring;
global using System;
global using System.IO;
namespace ASimpleRPG;
using ASimpleRPG.WorldData;
using OddsLibrary.IO;
using ASimpleRPG.Entities;
using ASimpleRPG.Logging;
using ASimpleRPG.Database;
public static class Master
{
	public static World WorldInstance { get; private set; } = new World.Hub();
	internal static WorldObj<PlayableCharacter> player;
	static Master()
	{
		Debug.ApplyDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{Data.sourceFolder}logs\\", $"{DateTime.Today}.txt");
		Startup.AssignTitle();
		if (System.Diagnostics.Debugger.IsAttached)
		{
			Debug.LogWarning($"Using Demo Control..", Debug.SubCategory.Demo);
			player = new(new PlayableCharacter(), 0, 0, 0);
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