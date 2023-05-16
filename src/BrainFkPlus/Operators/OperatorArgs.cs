namespace BrainFkPlus.Operators;

/// <summary>
/// Contains references to parser variables. Used in IOperator.Run
/// </summary>
public ref struct OperatorArgs
{
    // as this is only c# 11 (.net 7.0) feature, it was replaced by implementation of Ref<T>
    // private ref int _CellIndex;
    // public ref int CellIndex => ref _CellIndex;

    // private ref int _CellValue;
    // public ref int CellValue => ref _CellValue;

    // private ref int _CodeIndex;
    // public ref int CodeIndex => ref _CodeIndex;

    /// <summary>
    /// Reference to current cell index, can be overriden
    /// </summary>
    public Ref<int> CellIndex { get; }
    /// <summary>
    /// Reference to current cell value, can be overriden
    /// </summary>
    public Ref<int> CellValue { get; }
    /// <summary>
    /// Reference to current parser index, can be overriden
    /// </summary>
    public Ref<int> CodeIndex { get; }
    /// <summary>
    /// Reference to next cell value, can be overriden
    /// </summary>
    public Ref<int> NextCell { get; }

    /// <summary>
    /// Current parsed character
    /// </summary>
    public char CurrentChar { get; init; }
    /// <summary>
    /// Code, that being parsed
    /// </summary>
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