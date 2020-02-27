using System;
using UserManagement.DataAccess;

namespace UserManagement.Business
{
    public class UnitOfWork : IDisposable
    {
        protected IDataContext DataContext { get; set; }

        private bool Disposed;

        public UnitOfWork(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DataContext.Dispose();
                }
                Disposed = true;
            }
        }
    }
}
