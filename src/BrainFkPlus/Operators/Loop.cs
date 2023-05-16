namespace BrainFkPlus.Operators;

internal sealed class Loop : IOperator
{
    static int b = 0;

    public void Run(OperatorArgs args)
    {
        if (args.CurrentChar == '[')
        {
            if (args.CellValue.Value > 0) return;
            ++b;
            while (b != 1)
            {
                switch (args.Code[++args.CodeIndex.Value])
                {
                    case '[': ++b; break;
                    case ']': --b; break;
                }
            }
        }
        else if (args.CurrentChar == ']')
        {
            if (args.CellValue.Value < 1) return;
            ++b;
            while (b != 1)
            {
                switch (args.Code[--args.CodeIndex.Value])
                {
                    case '[': --b; break;
                    case ']': ++b; break;
                }
            }
            --args.CodeIndex.Value;
        }
    }

    public bool Validate(char currentChar) =>
        currentChar == '[' || currentChar == ']';
}