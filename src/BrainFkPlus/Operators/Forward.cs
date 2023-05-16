namespace BrainFkPlus.Operators;

internal sealed class Forward : IOperator
{
    public void Run(OperatorArgs args)
    {
        ++args.CellIndex.Value;
    }

    public bool Validate(char currentChar) =>
        currentChar == '>';
}