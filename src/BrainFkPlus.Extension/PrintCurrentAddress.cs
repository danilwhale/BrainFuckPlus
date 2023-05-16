using BrainFkPlus.Operators;

namespace BrainFkPlus.Extension;

public sealed class PrintCurrentAddress : IOperator
{
    public void Run(OperatorArgs args)
    {
        Console.Write(args.CellIndex.Value);
    }

    public bool Validate(char currentChar)
    {
        return currentChar == '?';
    }
}