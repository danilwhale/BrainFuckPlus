using BrainFkPlus.Operators;

namespace BrainFkPlus.Extension;

public sealed class Endl : IOperator
{
    public void Run(OperatorArgs args)
    {
        Console.WriteLine();
    }

    public bool Validate(char currentChar)
    {
        return currentChar == ';';
    }
}