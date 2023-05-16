using System.Runtime.InteropServices;

namespace BrainFkPlus;

public ref struct Ref<T>
{
    readonly Span<T> _value;

    public ref T Value => ref MemoryMarshal.GetReference(_value);

    public Ref(ref T value)
    {
        _value = MemoryMarshal.CreateSpan<T>(ref value, 1);
    }
}

