﻿using System;
using ASimpleRPG.WorldData;
using OddsLibrary.IO;
using ASimpleRPG.Entities;
using ASimpleRPG.Logging;
namespace ASimpleRPG;
public static class Master
{
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
		Debug.Log($"Setted Title: {Console.Title}", "Startup");
		DemoControl();
	}
	private static void DemoControl()
	{
		Debug.Log($"Using Demo Control..", "Demo");
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