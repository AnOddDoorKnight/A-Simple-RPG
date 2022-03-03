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
	public static void Log(string message) => Log(message, isError: false);
	public static void Log(string message, SubCategory subcategory) => 
		Log(message, subcategory, false);
	public static void LogWarning(string message) => Log(message, isError: null);
	public static void LogWarning(string message, SubCategory subcategory) => 
		Log(message, subcategory, null);
	public static void LogError(string message) => 
		Log(message, isError: true);
	public static void LogError(string message, SubCategory subcategory) =>
		Log(message, subcategory, true);
	private static void Log(string message, SubCategory? subcategory = null, bool? isError = false)
	{
		if (FileDirectory == null || fileName == null) throw new NullReferenceException();
		string currentLog = File.ReadAllText(FileLocation
			+ $"\n[{isError switch { true => "Info", false => "Error", null => "Warning" }}"
			+ $"/{(subcategory != null ? $"/{subcategory}" : "")}] {message}");
		File.WriteAllLines(FileLocation, currentLog.Split('\n'));
	}
	public enum SubCategory
	{
		Startup,
		Demo,
		CreateArea,
		CreateObject,
		CreateCreature,
		Rendering
	}
}