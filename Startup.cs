﻿namespace ASimpleRPG;using System;using System.IO;using ASimpleRPG.Entities;using Vectoring;using ASimpleRPG.Logging;internal static class Startup{	private static string GetSubTitle()	{		string output = "";		string?[] yellowText =		{			null,			"Your fist is your weapon!",			"1 + 1 = 0",			"1 + 1 = 10",			"Ultra Greatbows",			"Great Crossbows are just portable ballistas",			"The Rats Chosen Undead, Why are they invincible?",			"Now with 50% more pain!",			"Remastered",			"Professor of the First Sin",			"Pointeth Downward",		};		Random random = new();		while (true)		{			int i = random.Next(yellowText.Length);			if (yellowText[i] == null) output += GetSubTitle();			else return output;		}	}	public static string AssignTitle()	{		// https://minecraft.fandom.com/wiki/Splash		// https://terraria.fandom.com/wiki/Title_messages		string title = $"A-Simple-RPG: {GetSubTitle()}";		Console.Title = title;		Debug.Log($"Setted Title: {title}", Debug.SubCategory.Startup);		return title;	}	public static WorldObj<PlayableCharacter> GetSavedCharacter()	{		WorldObj<PlayableCharacter> player;		ISaveManager sv = new PlayableCharacter();		try 		{			Debug.Log("Loading saved Character..", Debug.SubCategory.CreateObject);			player = sv.Load<WorldObj<PlayableCharacter>>(); 		}		catch (FileNotFoundException) 		{			Debug.LogWarning("Cannot find player data, starting new game..", Debug.SubCategory.CreateObject);			player = new(new PlayableCharacter(), 0, 0, 0); 		}		return player;	}}