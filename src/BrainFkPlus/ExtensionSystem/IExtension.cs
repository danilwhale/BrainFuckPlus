namespace BrainFkPlus.ExtensionSystem;

public interface IExtension
{
    string Name { get; }
    string Author { get; }
    string Version { get; }

    void OnLoad();
    void OnConfiguration(Compiler compiler);
    void OnCompiled(int[] cells);
}