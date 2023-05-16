namespace BrainFkPlus;

/// <summary>
/// Contains basic logging functionality
/// </summary>
public static class Logging
{
    /// <summary>
    /// Level of log message
    /// </summary>
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error,
        Fatal
    }

    /// <summary>
    /// Logs message with specified level
    /// </summary>
    /// <param name="message">Message to log</param>
    /// <param name="level">Level of log</param>
    public static void Log(string message, LogLevel level = LogLevel.Info)
    {
        string msg = level switch
        {
            LogLevel.Debug => "[DBG]",
            LogLevel.Info => "[INF]",
            LogLevel.Warning => "[WRN]",
            LogLevel.Error => "[ERR]",
            LogLevel.Fatal => "[FTL]",
            _ => "[ANY]"
        };

        msg += " " + message;

        Console.ForegroundColor = level switch
        {
            LogLevel.Debug => ConsoleColor.DarkYellow,
            LogLevel.Info => ConsoleColor.Blue,
            LogLevel.Warning => ConsoleColor.Yellow,
            LogLevel.Error => ConsoleColor.Red,
            LogLevel.Fatal => ConsoleColor.DarkRed,
            _ => ConsoleColor.White
        };

        Console.WriteLine(msg);

        Console.ResetColor();
    }
}