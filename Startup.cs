namespace ASimpleRPG;

using System;
using System.IO;
using Entities;
using Vectoring;
using Logging;


internal static class Startup
{
	private static string GetSubTitle()
	{
		string?[] yellowText =
		{
			null, // Recursion Joke
			"Your fist is your weapon!",
			"1 + 1 = 10",
			"\"1\" + 1 + 2 + 5 = 1125",
			"Ultra Greatbows",
			"Great Crossbows are just portable ballistas",
			"Now with 50% more pain!",
			"Remastered",
			"Youngster of the First Sin",
			"Pointeth Downward",
			"Poke Poke Poke Poke Poke Poke Poke Poke Poke Poke Poke Poke Poke Poke..",
			"sex",

		};
		Random random = new();
		int i = random.Next(yellowText.Length);
		if (yellowText[i] == null)
			return Recursion(random);
		else return yellowText[i]!;
	}
	public static string AssignTitle(string gameName)
	{
		// https://minecraft.fandom.com/wiki/Splash
		// https://terraria.fandom.com/wiki/Title_messages
		string title = $"{gameName}: {GetSubTitle()}";
		Console.Title = title;
		Debug.Log($"Changed Title: {title}", Debug.SubCategory.Startup);
		return title;
	}
	public static WorldObj<PlayableCharacter> GetSavedCharacter()
	{
		WorldObj<PlayableCharacter> player;
		ISaveManager sv = new PlayableCharacter();
		try 
		{
			Debug.Log("Loading saved Character..", Debug.SubCategory.CreateObject);
			player = sv.Load<WorldObj<PlayableCharacter>>(); 
		}
		catch (FileNotFoundException) 
		{
			Debug.LogWarning("Cannot find player data, starting new game..", Debug.SubCategory.CreateObject);
			player = new(new PlayableCharacter(), 0, 0, 0); 
		}
		return player;
	}
	static string Recursion(Random random)
	{
		if (random.Next(2) == 1)
			return $"Recursion Is {Recursion(random)}";
		else return "cool!";
	}
}