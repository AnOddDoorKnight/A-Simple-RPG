using System;
using ASimpleRPG.WorldData;
using OddsLibrary.IO;
using ASimpleRPG.Entities;
using ASimpleRPG.Logging;
namespace ASimpleRPG;
public static class Master
{
	public static Debug debug = new($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{sourceFolder}logs\\", $"{DateTime.Today}.txt");
	static readonly string saveName = "Save.sl2", sourceFolder = @"\ASimpleRPG\";
	static FileManager saveFile = new($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\ASimpleRPG\{saveName}", true);
	public static World WorldInstance { get; private set; } = new World.Hub();
	internal static WorldObj<PlayableCharacter> player;
	//static World World = new WorldData.Void();
	static Master()
	{
		// https://terraria.fandom.com/wiki/Title_messages
		string[] yellowText =
		{	"return splashText[Random.Next(splashText.Length)]",
			"Your fist is your weapon!",
			"1 + 1 = 0"
		};
		Console.Title = $"A-Simple-RPG: {yellowText[new Random().Next(yellowText.Length)]}";
		if (OperatingSystem.IsWindows()) debug.Log($"Setted Title: {Console.Title}", Debug.SubCategory.Startup);
		else debug.LogWarning($"Setted Title: Unable to display title due to operating system", Debug.SubCategory.Startup);
		DemoControl();
	}
	/// <summary>
	/// Runs a method for testing the game, should not be in the final build
	/// </summary>
	private static void DemoControl()
	{
		debug.LogWarning($"Using Demo Control..", Debug.SubCategory.Demo);
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
// Might not be used, but is here due to updates in personal essentials
public enum CreatureType
{
	Player,
	Slime
}