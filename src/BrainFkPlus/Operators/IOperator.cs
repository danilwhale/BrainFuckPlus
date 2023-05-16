namespace BrainFkPlus.Operators;

/// <summary>
/// Operator for compiler to understand
/// </summary>
/// <remarks>
/// Must be registered by Compiler.RegisterOp(IOperator) to use it from BF+ code
/// </remarks>
public interface IOperator
{
    void Run(OperatorArgs args);
    bool Validate(char currentChar);
}