namespace BrainFkPlus.Operators;

internal sealed class PrintChar : IOperator
{
    public void Run(OperatorArgs args)
    {
        Console.Write((char)args.CellValue.Value);
    }

    public bool Validate(char currentChar) =>
        currentChar == '.';
}