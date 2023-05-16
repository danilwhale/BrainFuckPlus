using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace BrainFkPlus.ExtensionSystem;

public static class ExtensionManager
{
    public const string EXTENSIONS_ROOT = "ext/";
    internal static List<IExtension> _loadedExtensions = new List<IExtension>();

    internal static void LoadExtensions()
    {
        if (!Directory.Exists(EXTENSIONS_ROOT))
        {
            return;
        }

        foreach (var asm in Directory.EnumerateFiles(EXTENSIONS_ROOT, "*.dll"))
        {
            if (TryGetExtensions(asm, out var exts))
            {
                _loadedExtensions.AddRange(exts);
                foreach (var ext in exts) ext.OnLoad();
            }
            else
            {
                Utilities.Log("Unable to load assembly " + asm, Utilities.LogLevel.Warning);
            }
        }
    }

    static bool TryGetExtensions(string file, [NotNullWhen(true)] out IExtension[] extensions)
    {
        extensions = Array.Empty<IExtension>();

        if (!File.Exists(file))
        {
            return false;
        }

        try
        {
            var asm = Assembly.LoadFile(Path.GetFullPath(file));
            var types = asm.GetExportedTypes()
                        .Where(t => t.IsAssignableTo(typeof(IExtension)))
                        .ToArray();
            var exts = new List<IExtension>();

            if (types.Length < 1) return true;

            foreach (var t in types)
            {
                var ext = (IExtension?)Activator.CreateInstance(t);
                if (ext != null)
                    exts.Add(ext);
            }

            extensions = exts.ToArray();
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}