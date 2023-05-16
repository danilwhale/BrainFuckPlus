namespace BrainFkPlus.ExtensionSystem;

/// <summary>
/// Base interface for extensions
/// </summary>
public interface IExtension
{
    /// <summary>
    /// Display name of extension
    /// </summary>
    /// <remarks>
    /// May be removed in future versions
    /// </remarks>
    string Name { [Obsolete] get; }
    /// <summary>
    /// Author of extension
    /// </summary>
    /// <remarks>
    /// May be removed in future versions
    /// </remarks>
    string Author { [Obsolete] get; }
    /// <summary>
    /// Version of extension
    /// </summary>
    /// <remarks>
    /// May be removed in future versions
    /// </remarks>
    string Version { [Obsolete] get; }

    /// <summary>
    /// Invokes when extension is being loaded by ExtensionManager
    /// </summary>
    void OnLoad();
    /// <summary>
    /// Invokes when compiler needs configuration (ex. registering operators)
    /// </summary>
    /// <param name="compiler">Instance of Compiler</param>
    void OnConfiguration(Compiler compiler);
    /// <summary>
    /// Invokes when script is successfully compiled
    /// </summary>
    /// <param name="cells">Array with cells, that was used by script</param>
    void OnCompiled(int[] cells);
}