namespace BrainFkPlus.Operators;

internal sealed class GetVal : IOperator
{
    public void Run(OperatorArgs args)
    {
        args.CellValue.Value = Console.ReadKey().KeyChar;
    }

    public bool Validate(char currentChar) =>
        currentChar == ',';
}