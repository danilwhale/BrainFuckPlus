namespace BrainFkPlus.Operators;

public ref struct OperatorArgs
{
    // as this is only c# 11 (.net 7.0) feature, it was replaced by implementation
    // of Ref<T>
    // private ref int _CellIndex;
    // public ref int CellIndex => ref _CellIndex;

    // private ref int _CellValue;
    // public ref int CellValue => ref _CellValue;

    // private ref int _CodeIndex;
    // public ref int CodeIndex => ref _CodeIndex;

    public Ref<int> CellIndex { get; }
    public Ref<int> CellValue { get; }
    public Ref<int> CodeIndex { get; }
    public Ref<int> NextCell { get; }

    public char CurrentChar { get; init; }
    public string Code { get; init; }

    internal OperatorArgs(
        ref int cellIndex, ref int cellValue, ref int codeIndex, 
        ref int nextCell, string code, char currentChar)
    {
        CellIndex = new Ref<int>(ref cellIndex);
        CellValue = new Ref<int>(ref cellValue);
        CodeIndex = new Ref<int>(ref codeIndex);
        NextCell = new Ref<int>(ref nextCell);
        Code = code;
        CurrentChar = currentChar;
    }
}