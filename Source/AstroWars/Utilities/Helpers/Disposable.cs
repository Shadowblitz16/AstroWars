
public abstract class Disposable : IDisposable
{
    bool _disposed = false;

    ~Disposable()
    {
        Dispose();
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;

        OnDispose();
        GC.SuppressFinalize(this);
    }

    protected virtual void OnDispose()
    {

    }

    protected bool IsDisposed()
    {
        return _disposed;
    }
}