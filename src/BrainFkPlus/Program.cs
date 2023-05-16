using System.Diagnostics;
using BrainFkPlus;
using BrainFkPlus.ExtensionSystem;
using BrainFkPlus.Operators;

// var file = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "brainfkplus.exe");
// var verInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(file);

// Utilities.Log("BrainFuck+/BrainFuck Interpreter");
// Utilities.Log("version " + verInfo.FileVersion);
// Console.WriteLine();

if (args.Length < 1)
{
    Logging.Log("Specify script to execute (extensions: " + string.Join(", ", Parser.AllowedExtensions) + ")");
    return 1;
}

if (!File.Exists(args[0]))
{
    Logging.Log("File not found", Logging.LogLevel.Fatal);
    return 1;
}
if (!Parser.AllowedExtensions.Contains(Path.GetExtension(args[0])))
{
    Logging.Log("Unrecognized file extension: " + Path.GetExtension(args[0]), Logging.LogLevel.Fatal);
    Logging.Log("Extension must be one of following: " + string.Join(' ', Parser.AllowedExtensions));
    return 1;
}

if (!Parser.BrainFuckExtensions.Contains(Path.GetExtension(args[0])))
    ExtensionManager.LoadExtensions();
else
    Logging.Log("Specified file is BrainFuck, skipping extensions load");

try
{
    var compiler = new Compiler()
        .RegisterOperator<Increment>()
        .RegisterOperator<Decrement>()
        .RegisterOperator<Forward>()
        .RegisterOperator<Backwards>()
        .RegisterOperator<PrintChar>()
        .RegisterOperator<GetVal>()
        .RegisterOperator<Loop>();
    
    foreach (var ext in ExtensionManager._loadedExtensions)
    {
        ext.OnConfiguration(compiler);
    }

    var stopwatch = new Stopwatch();
    stopwatch.Start();

    var parser = new Parser(compiler, args[0]);
    parser.Execute();

    Console.WriteLine();
    Logging.Log("Spent " + stopwatch.ElapsedMilliseconds + " ms on compiling");
}
catch (Exception ex)
{
    Logging.Log("We have problems!\n\t> " + ex.GetType().FullName + " - " + ex.Message, Logging.LogLevel.Fatal);
}

return 0;