global using OddsLibrary.Name.Fantasy;
global using OddsLibrary.IO;
global using System;
global using System.Collections.Generic;
using System.IO;
using ASimpleRPG.Entities.Char;

namespace ASimpleRPG;

static class Master
{
	static Character character;
	static Master()
    {
		Console.Title = $"ASimpleRPG: {SplashTitle()}";
		Console.WriteLine("By AnOddDoorKnight#0068");
		FileManager.DirectoryBuilder($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\ASimpleRPG\Saves.ddl");
		character = Saves.Load();
	}
	static void Main()
	{
		
	}
	static class Idle
	{

	}
	static class Fight
	{

	}
	// Use OddsLibrary for this!	
	//if (File.ReadAllLines(saveDataDirectory).Length > 0) character = new(true);
	//else character = new(false);
	
	// https://terraria.fandom.com/wiki/Title_messages
	static string SplashTitle() => yellowText[new Random().Next(yellowText.Length)];
	static readonly string[] yellowText = new string[]
	{
		"return splashText[Random.Next(splashText.Length)]",
		"Your fist is your weapon!",
		"1 + 1 = 0"
	};
}
public static class Saves
{
	static Saves()
	{
		basePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\ASimpleRPG\";
		savePath = $"{basePath}sv_0.sl2";
		// This is here as to save processing power everytime we load or save data, see the end of public static void Save(in Character input)
		saveFile = File.ReadAllLines(savePath);
	}
	public static readonly string basePath,
		savePath;
	static string[] saveFile;
	public static string GetSaveArray(BasicStorage inputSelection) => inputSelection switch
	{
		BasicStorage.Name => saveFile[0],
		_ => saveFile[1]
	};
	public static string[] GetSaveArray(ArrayStorage inputSelection) => inputSelection switch
	{
		ArrayStorage.Level => new string[]
		{
			saveFile[2].Split(' ')[0],
			saveFile[2].Split(' ')[1]
		},
		ArrayStorage.Stats => new string[]
		{
			// Perhaps creating a string[] for it instead of making it multiple times may help
			saveFile[3].Split(' ')[0],
			saveFile[3].Split(' ')[1],
			saveFile[3].Split(' ')[2],
			saveFile[3].Split(' ')[3],
			saveFile[3].Split(' ')[4],
			saveFile[3].Split(' ')[5],
		}
	};
	public enum BasicStorage
	{
		Name,
		Class
	}
	public enum ArrayStorage
	{
		Level,
		Stats
	}
	public static Character Load()
	{
		string[] StatsStr = GetSaveArray(ArrayStorage.Stats);
		return saveFile.Length > 0 ? new()
		{
			Name = saveFile[0].Length == 0 ? null : saveFile[0],
			Class = saveFile[1].Length == 0 ? null : Enum.Parse<Class>(saveFile[1]),
			Level = new Level()
			{
				CurrentLevel = Convert.ToByte(saveFile[2].Split(' ')[0]),
				Experience = Convert.ToByte(saveFile[2].Split(' ')[1])
			},
			Stats = new Stats()
			{
				saveFile[3]
			}
		} : new();
	}
	// Example:
	// Character Name
	// Class
	// 

	public static void Save(in Character input)
	{
		/// For now, inventory is not gonna be recorded, as it is not finished
		// string[] inventory = new string[input.inventory.Count];
		// for (int i = 0; i < input.inventory.Count; i++) inventory[i] =  
		string statistics = "";
		foreach (Stats.Stat i in input.Stats.Statistics.Values) 
			statistics += $@"{i.Value} ";
		string[] fileContents = 
		{
			input.Name ?? "",
			input.Class.ToString() ?? "",
			$"{input.Level.CurrentLevel} {input.Level.Experience}",
			$"{statistics.Trim()}"
		};
		//File.WriteAllText(savePath, $"{input.Name ?? "null"}\n" +$"{input.Class}\n" +$"<Inventory>\n" +$"");
		saveFile = File.ReadAllLines(savePath);
	}

	
}
