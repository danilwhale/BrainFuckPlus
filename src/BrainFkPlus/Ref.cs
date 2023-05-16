using System.Runtime.InteropServices;

namespace BrainFkPlus;

/// <summary>
/// Alternative to C# 11's 'ref field'
/// </summary>
/// <typeparam name="T">Type of reference</typeparam>
public ref struct Ref<T>
{
    readonly Span<T> _value;

    /// <summary>
    /// Referenced value, that can be modified at any moment
    /// </summary>
    public ref T Value => ref MemoryMarshal.GetReference(_value);

    /// <summary>
    /// Creates reference to value
    /// </summary>
    /// <param name="value"></param>
    public Ref(ref T value)
    {
        _value = MemoryMarshal.CreateSpan<T>(ref value, 1);
    }
}

