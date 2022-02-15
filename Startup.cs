namespace ASimpleRPG;
using System;
internal static class Startup
{
	public static string AssignTitle()
	{
		// https://minecraft.fandom.com/wiki/Splash
		// https://terraria.fandom.com/wiki/Title_messages
		string[] yellowText =
		{   "\"A-Simple-RPG: {yellowText[new Random().Next(yellowText.Length)]};",
			"Your fist is your weapon!",
			"1 + 1 = 0",
			"1 + 1 = 10",
			"Ultra Greatbows",
			"Great Crossbows are just portable ballistas",
			"Point down at the bugs, it will rid of them out of saltiness!",
		};
		string title = $"A-Simple-RPG: {yellowText[new Random().Next(yellowText.Length)]}";
		Console.Title = title;
		Master.debug.Log($"Setted Title: {title}", Logging.Debug.SubCategory.Startup);
		return title;
	}
}