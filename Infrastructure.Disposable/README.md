About

The package is designed for disposing objects in .NET applications.

How to Use

1. Class with managed resources only

You do not need to override the Dispose(bool) method in the class.

    public class SimpleRepository : DisposableBase
    {
        private readonly ContractGpdDbContextBase _dbContext;

        public SimpleRepository(ContractGpdDbContextBase dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void DisposeManagedResources()
        {
            _dbContext?.Dispose();
        }
    }

2. Class with unmanaged resources

You do not need to override the DisposeUnmanagedResources() method in the class.

    public class SpecialRepository : DisposableBase
    {
        private readonly ContractGpdDbContextBase _dbContext;
        private IntPtr _nativeHandle;

        public SpecialRepository(ContractGpdDbContextBase dbContext, IntPtr nativeHandle)
        {
            _dbContext = dbContext;
            _nativeHandle = nativeHandle;
        }

        protected override void DisposeManagedResources()
        {
            _dbContext?.Dispose();
        }

        protected override void DisposeUnmanagedResources()
        {
            if (_nativeHandle != IntPtr.Zero)
            {
                NativeMethods.CloseHandle(_nativeHandle);
                _nativeHandle = IntPtr.Zero;
            }
        }
    }

3. Class with logging

You do not need to override the Dispose(bool) method in the class.

    public class AuditedRepository : DisposableBase
    {
        private readonly ILogger _logger;

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _logger.LogInformation("Freeing resources for {Type}", GetType().Name);

                base.Dispose(disposing);

                _logger.LogInformation("Resources released for {Type}", GetType().Name);
            }
        }
    }

4. Class with asynchronous resource disposal

    public class AsyncRepository : DisposableBase
    {
        private readonly ContractGpdDbContextBase _dbContext;

        public AsyncRepository(ContractGpdDbContextBase dbContext)
        {
            _dbContext = dbContext;
        }

        // Override for async cleanup
        protected override async ValueTask DisposeManagedResourcesAsync()
        {
            if (_dbContext != null)
            {
                await _dbContext.DisposeAsync().ConfigureAwait(false);
            }
        }

        // Optional: also override sync disposal for compatibility
        protected override void DisposeManagedResources()
        {
            _dbContext?.Dispose();
        }
    }

Usage examples:

Synchronous disposal (using):

    using (var repo = new AsyncRepository(context))
    {
        // work with repository
    }

Asynchronous disposal (await using):

    await using (var repo = new AsyncRepository(context))
    {
        // work with repository
    }



Main Types  

The main types provided by this library are:

    Infrastructure.Disposable.DisposableBase


Feedback & Contributing

Infrastructure.Disposable is released as open source under the MIT license. Bug reports and contributions are welcome at the GitHub repository.