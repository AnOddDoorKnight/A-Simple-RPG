namespace ASimpleRPG.Logging;
using System.IO;
using System;
using OddsLibrary.IO;
public static class Debug
{
    static string fileLocation = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{Master.sourceFolder}logs\{DateTime.Today}.txt";
    static Debug()
    {
        FileManager manager = new(fileLocation);
        manager.BuildFile();
    }
    public static void Log(string message) => Log(message, isError: false);
    public static void Log(string message, string subcategory) => log(message, subcategory, false);
    public static void LogWarning(string message) => Log(message, isError: null);
    public static void LogWarning(string message, string subcategory) => Log(message, subcategory, null);
    public static void LogError(string message) => Log(message, isError: true);
    public static void LogError(string message, string subcategory) => Log(message, subcategory, true);
    private static void Log(string message, string? subcategory = null, bool? isError = false)
    {
        string currentLog = File.ReadAllText(fileLocation);
        currentLog += $"\n[{isError switch {true => "Info", false => "Error", null => "Warning"}}}{(subcategory != null ? $"/{subcategory}" : "")}] {message}";
        File.WriteAllLines(fileLocation, currentLog);
    }
}