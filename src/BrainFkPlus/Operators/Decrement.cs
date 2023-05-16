namespace BrainFkPlus.Operators;

internal sealed class Decrement : IOperator
{
    public void Run(OperatorArgs args)
    {
        --args.CellValue.Value;
    }

    public bool Validate(char currentChar) =>
        currentChar == '-';
}