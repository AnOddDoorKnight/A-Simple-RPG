﻿using System;
using OddsLibrary.IO;
using ASimpleRPG.Entities;
namespace ASimpleRPG;
public static class Master
{
	const string saveName = "Save.sl2", sourceFolder = @"\ASimpleRPG\";
	static FileManager saveFile = new($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\ASimpleRPG\{saveName}", true);
	static Human player;
	static Master()
	{
		// https://terraria.fandom.com/wiki/Title_messages
		string[] yellowText =
		{
			"return splashText[Random.Next(splashText.Length)]",
			"Your fist is your weapon!",
			"1 + 1 = 0"
		};
		Console.Title = $"A-Simple-RPG: {yellowText[new Random().Next(yellowText.Length)]}";
		// This is for demo control only!
		player = new Human();
		NewRound += player.StatusEffects.LowerByRound;
	}
	static void Main()
	{
		Console.WriteLine($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{sourceFolder}{saveName}");
	}
	public static event EventHandler NewRound;
	public static void InvokeNewRound() => NewRound?.Invoke(null, EventArgs.Empty);
}
public interface ISaveManager
{
	void Load();
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