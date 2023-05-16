using BrainFkPlus.Operators;

namespace BrainFkPlus.Extension;

public sealed class DivideOp : IOperator
{
    public void Run(OperatorArgs args)
    {
        args.CellValue.Value /= args.NextCell.Value;
    }

    public bool Validate(char currentChar)
    {
        return currentChar == '/';
    }
}