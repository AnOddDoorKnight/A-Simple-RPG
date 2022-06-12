namespace ASimpleRPG.Logging;

using System.IO;
using System;
using OddsLibrary.IO;


public static class Debug
{
	static string FileLocation => fileDirectory + fileName;
	private static string? fileDirectory, fileName;
	public static string? FileDirectory 
	{ 
		get => fileDirectory; 
		set 
		{ 
			fileDirectory = value; 
			new FileManager(value?.ToString()!, false).BuildPath(); 
		} 
	}
	public static string? FileName
	{
		get => fileName;
		set
		{
			fileName = value;
			FileManager file = new(FileDirectory + value?.ToString()!, true);
			file.BuildFile();

		}
	}
	public static void ApplyDirectory(string fileDirectory, string fileName)
	{
		FileDirectory = fileDirectory;
		FileName = fileName;
	}
	public static void Log(string message, SubCategory? category = null)
		=> Log(message, DefineBox(false, category));
	public static void LogWarning(string message, SubCategory? category = null)
		=> Log(message, DefineBox(null, category));
	public static void LogError(string message, SubCategory? category = null)
		=> Log(message, DefineBox(true, category));
	static string DefineBox(bool? type, SubCategory? category = null)
	{
		if (category == null && type == false)
			return "";
		else
		{
			string box = "[{0}{1}]";

			// Assigning Severity
			if (type == false) box = box.Replace("{0}", "");
			else box = box.Replace
				("{0}", type switch {true => "Error, ", _ => "Warning, "});

			// Assigning Type
			box = box.Replace("{1}", category.ToString() ?? "");
			return box;
		}
	}
	static void Log(string message, string box)
	{
		if (FileDirectory == null || fileName == null)
			throw new NullReferenceException();
		string file = File.ReadAllText(FileLocation);
		file += $"\n{DateTime.Now} {box} {message}";
		File.WriteAllText(FileLocation, file);
	}
	public enum SubCategory
	{
		Startup,
		Demo,
		CreateArea,
		CreateObject,
		CreateCreature,
		CreateEvent,
		CreateAction,
		Rendering
	}
}