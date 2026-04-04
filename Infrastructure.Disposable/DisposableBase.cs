namespace Infrastructure.Disposable;

/// <summary>
/// Базовый механизм освобождения ресурсов с поддержкой синхронного и асинхронного освобождения.
/// </summary>
public abstract class DisposableBase : IDisposable, IAsyncDisposable
{
    private bool _disposed = false;

    /// <summary>
    /// Освобождает управляемые ресурсы (синхронно).
    /// </summary>
    protected abstract void DisposeManagedResources();

    /// <summary>
    /// Асинхронно освобождает управляемые ресурсы. Реализация по умолчанию вызывает синхронный метод.
    /// </summary>
    protected virtual ValueTask DisposeManagedResourcesAsync()
    {
        DisposeManagedResources();
        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// Освобождает неуправляемые ресурсы.
    /// </summary>
    protected virtual void DisposeUnmanagedResources() { }

    /// <summary>
    /// Синхронно освобождает ресурсы в зависимости от источника вызова.
    /// </summary>
    /// <param name="disposing">
    /// <c>true</c> — вызывается из внешнего кода (через <see cref="IDisposable.Dispose"/>).<br/>
    /// <c>false</c> — вызывается из финализатора.<br/>
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
    /// Асинхронно освобождает ресурсы в зависимости от источника вызова.
    /// </summary>
    /// <param name="disposing">
    /// <c>true</c> — вызывается из <see cref="IAsyncDisposable.DisposeAsync"/>.<br/>
    /// <c>false</c> — не вызывается из финализатора (финализатор вызывает только синхронный <see cref="Dispose(bool)"/>).<br/>
    ///</param>
    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (!_disposed)
        {
            // Неуправляемые ресурсы освобождаются синхронно
            DisposeUnmanagedResources();

            if (disposing)
            {
                await DisposeManagedResourcesAsync().ConfigureAwait(false);
            }

            _disposed = true;
        }
    }

    /// <summary>
    /// Синхронно освобождает ресурсы.
    /// </summary>
    /// <remarks>Метод вызывается явно или сборщиком мусора.</remarks>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Асинхронно освобождает ресурсы.
    /// </summary>
    /// <returns>Задача, представляющая асинхронную операцию освобождения.</returns>
    /// <remarks>Метод вызывается явно через <see cref="IAsyncDisposable.DisposeAsync"/>.</remarks>
    public ValueTask DisposeAsync() => DisposeAsync(true);

    /// <summary>
    /// Финализатор, гарантирующий освобождение неуправляемых ресурсов, если метод <see cref="IDisposable.Dispose"/> 
    /// не был вызван явно.
    /// </summary>
    ~DisposableBase() => Dispose(false);
}
