namespace ASimpleRPG.Logging;
using System.IO;
using System;
using OddsLibrary.IO;
public class Debug
{
    string FileLocation => fileDirectory + fileName;
    string fileDirectory, fileName;
    public Debug(string fileLocation, string fileName)
	{
        fileDirectory = fileLocation;
        this.fileName = fileName;
        new FileManager(FileLocation).BuildFile();
	}
    public void Log(string message) => Log(message, isError: false);
    public void Log(string message, SubCategory subcategory) => Log(message, subcategory, false);
    public void LogWarning(string message) => Log(message, isError: null);
    public void LogWarning(string message, SubCategory subcategory) => Log(message, subcategory, null);
    public void LogError(string message) => Log(message, isError: true);
    public void LogError(string message, SubCategory subcategory) => Log(message, subcategory, true);
    private void Log(string message, SubCategory? subcategory = null, bool? isError = false)
    {
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