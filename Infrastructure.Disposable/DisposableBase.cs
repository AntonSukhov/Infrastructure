namespace Infrastructure.Disposable;

/// <summary>
/// Базовый механизм освобождения ресурсов.
/// </summary>
public abstract class DisposableBase : IDisposable
{
    private bool _disposed = false;

    /// <summary>
    /// Освобождает управляемые ресурсы.
    /// </summary>
    protected abstract void DisposeManagedResources();

    /// <summary>
    /// Освобождает неуправляемые ресурсы.
    /// </summary>
    protected virtual void DisposeUnmanagedResources() { }

    /// <summary>
    /// Освобождает ресурсы в зависимости от источника вызова.
    /// </summary>
    /// <param name="disposing">
    /// <c>true</c> - вызывается из внешнего кода (через <see cref="IDisposable.Dispose"/>).<br/>
    /// <c>false</c> - вызывается из финализатора.<br/>
    ///</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            DisposeUnmanagedResources();

            if (disposing)
            {
                DisposeManagedResources();
            }

            _disposed = true;
        }
    }

    /// <summary>
    /// Освобождает ресурсы.
    /// </summary>
    /// <remarks>Метод вызывается явно или сборщиком мусора.</remarks>
    public void Dispose()
    {
        Dispose(true);

        //Подавляем финализацию.
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Освобождает ресурсы.
    /// </summary>
    /// <remarks>Гарантирует освобождение ресурсов, если метод <see cref="IDisposable.Dispose"/> не был вызван явно./remarks>
    ~DisposableBase() => Dispose(false);
}