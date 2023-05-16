namespace BrainFkPlus.Operators;

internal sealed class Backwards : IOperator
{
    public void Run(OperatorArgs args)
    {
        --args.CellIndex.Value;
    }

    public bool Validate(char currentChar) =>
        currentChar == '<';
}