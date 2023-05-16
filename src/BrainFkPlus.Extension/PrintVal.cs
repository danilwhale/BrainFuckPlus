using BrainFkPlus.Operators;

namespace BrainFkPlus.Extension;

public sealed class PrintVal : IOperator
{
    public void Run(OperatorArgs args)
    {
        Console.Write(args.CellValue.Value);
    }

    public bool Validate(char currentChar)
    {
        return currentChar == '_';
    }
}