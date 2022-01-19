using System;
using System.IO;
using OddsLibrary.IO;
using ASimpleRPG.Entities;
namespace ASimpleRPG;
public static class Master
{
	const string saveName = "Save.sl2", sourceFolder = @"\ASimpleRPG\";
	static FileManager saveFile = new($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\ASimpleRPG\{saveName}", true);
	static PlayableCharacter player;
	static Master()
	{
		// This is for demo control only!
		player = new PlayableCharacter();
		NewRound += player.StatusEffects.LowerByRound;
	}
	static void Main()
	{
		Console.WriteLine($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{sourceFolder}{saveName}");
	}
	public static event EventHandler NewRound;
	public static void InvokeNewRound() => NewRound?.Invoke(null, EventArgs.Empty);
}