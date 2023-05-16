using BrainFkPlus.ExtensionSystem;

namespace BrainFkPlus;

/// <summary>
/// Class, that clean ups code and pushes it to Compiler
/// </summary>
public class Parser
{
    internal static readonly string[] BrainFuckExtensions = { ".b", ".bf" };
    internal static readonly string[] BrainFuckPlusExtensions = { ".bp", ".b+", ".bfp", ".bf+" };

    internal static readonly string[] AllowedExtensions = BrainFuckExtensions.Concat(BrainFuckPlusExtensions).ToArray();

    public string FilePath { get; }
    public Compiler Compiler { get; }

    internal Parser(Compiler compiler, string filePath)
    {
        FilePath = filePath;
        Compiler = compiler;
    }

    /// <summary>
    /// Execute current script
    /// </summary>
    public void Execute()
    {
        string code = string.Empty;
        string[] rawCode = File.ReadAllLines(FilePath);

        // remove commentaries (and all unnecessary things)
        foreach (var ln in rawCode)
        {
            string trimLn = ln.Trim();

            if (trimLn.StartsWith("'")) continue;
            if (string.IsNullOrWhiteSpace(trimLn)) continue;

            

            int commentIndex = trimLn.IndexOf("'");
            if (commentIndex < 0) code += trimLn;
            else code += trimLn.Substring(0, commentIndex);
        }

        code = code.Replace(" ", null);

        // compile code
        var cells = Compiler.Compile(code);
        foreach (var ext in ExtensionManager._loadedExtensions)
        {
            ext.OnCompiled(cells);
        }
    }
}