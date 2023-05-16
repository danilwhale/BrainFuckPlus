using System.Collections.ObjectModel;
using System.Reflection;
using BrainFkPlus.ExtensionSystem;
using BrainFkPlus.Operators;

namespace BrainFkPlus;

/// <summary>
/// Compiles BrainFuck/BrainFuck+ script code
/// </summary>
public class Compiler
{
    /// <summary>
    /// Read-only collection of currently registered operators
    /// </summary>
    public ReadOnlyCollection<IOperator> RegisteredOperators => _registeredOperators.AsReadOnly();
    private List<IOperator> _registeredOperators;

    internal Compiler()
    {
        _registeredOperators = new List<IOperator>();
    }

    /// <summary>
    /// Compiles providen code to operators
    /// </summary>
    /// <param name="code">BrainFuck/BrainFuck+ code</param>
    /// <returns>Interpreted code with operators</returns>
    internal int[] Compile(string code)
    {
        int[] cells = new int[30_000];
        int ci = 0;

        for (int i = 0; i < code.Length; i++)
        {
            char c = code[i];

            var op = _registeredOperators.FirstOrDefault(o => o.Validate(c));
            if (op != null)
            {
                var args = new OperatorArgs(ref ci, ref cells[ci], ref i, ref cells[ci + 1], code, c);
                op.Run(args);
            } 
        }

        return cells;
    }
    // public int[] Compile(string code)
    // {
    //     int[] cells = new int[30_000];
    //     int ci = 0; // current cell index
    //     int b = 0; // status of loop branch

    //     for (int i = 0; i < code.Length; i++)
    //     {
    //         char c = code[i];

    //         switch (c)
    //         {
    //             // increment current cell value
    //             case '+':
    //                 cells[ci]++;
    //                 break;
    //             // decrement current cell value
    //             case '-':
    //                 cells[ci]--;
    //                 break;
    //             // move current cell index forwards
    //             case '>':
    //                 ci = Math.Clamp(ci + 1, 0, cells.Length - 1);
    //                 break;
    //             // move current cell index backwards
    //             case '<':
    //                 ci = Math.Clamp(ci - 1, 0, cells.Length - 1);
    //                 break;
    //             // print current cell char represantation to console
    //             case '.':
    //                 Console.Write((char)cells[ci]);
    //                 break;
    //             // put user input to current cell
    //             case ',':
    //                 cells[ci] = Console.ReadKey().KeyChar;
    //                 break;
    //             // print current cell value to console
    //             case '/':
    //                 Console.Write(cells[ci]);
    //                 break;
    //             // \n
    //             case '@':
    //                 Console.WriteLine();
    //                 break;
    //             // loop begin
    //             case '[':
    //                 if (cells[ci] > 0) break;
    //                 ++b;
    //                 while (b != 1)
    //                 {
    //                     switch (code[++i])
    //                     {
    //                         case '[': ++b; break;
    //                         case ']': --b; break;
    //                     }
    //                 }
    //                 break;
    //             // loop close
    //             case ']':
    //                 if (cells[ci] < 1) break;
    //                 ++b;
    //                 while (b != 1)
    //                 {
    //                     switch (code[--i])
    //                     {
    //                         case '[': --b; break;
    //                         case ']': ++b; break;
    //                     }
    //                 }
    //                 --i;
    //                 break;
    //         }
    //     }

    //     return cells;
    // }

    /// <summary>
    /// Registers IOperator of type T
    /// </summary>
    /// <typeparam name="T">Operator Type</typeparam>
    /// <returns>Compiler instance</returns>
    public Compiler RegisterOperator<T>() where T : IOperator
    {
        var constructor = typeof(T).GetConstructor(Array.Empty<Type>());
        if (constructor == null) return this;

        var op = constructor.Invoke(null);

        if (op is IOperator res)
            _registeredOperators.Add(res);

        return this;
    }
}