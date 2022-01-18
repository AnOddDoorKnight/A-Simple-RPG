using System;
using System.IO;
using OddsLibrary.IO;
using ASimpleRPG.Entities;
namespace ASimpleRPG;
static class Master
{
	const saveName = "Save.sl2";
	static FileManager saveFile = new($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\ASimpleRPG\{saveName}", true);
	static PlayableCharacter player;
	static Master()
	{

	}
	static void Main()
	{
		
	}
}