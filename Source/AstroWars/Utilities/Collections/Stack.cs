using System.Collections;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace AstroWars.Collections;

public class Stack<T>
{
    private readonly Stack<T> _value = new();
    public int Count { get; } 

    public void Push(T value)
    {
        _value.Push(value);
    }
    public T?   Peek()
    {
        return _value.Peek();
    }
    public T?   Pop ()
    {
        return _value.Pop();
    }
    public bool TryPeek(out T result)
    {
        if (_value.TryPeek(out result))
        {
            return true;
        }
        return false;
    }
    public bool TryPop(out T result)
    {
        if (_value.TryPop(out result))
        {
            return true;
        }
        return false;
    }
}