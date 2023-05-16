using BrainFkPlus.ExtensionSystem;

namespace BrainFkPlus.Extension;

public sealed class Extension : IExtension
{
    public string Name => "BrainFkPlus.Extension";

    public string Author => "danilwhale";

    public string Version => "1.0";

    public void OnCompiled(int[] cells)
    {
    }

    public void OnConfiguration(Compiler compiler)
    {
        compiler.RegisterOperator<PrintVal>()
                .RegisterOperator<Endl>()
                .RegisterOperator<MultiplyOp>()
                .RegisterOperator<DivideOp>();
    }

    public void OnLoad()
    {

    }
}