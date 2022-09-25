using System;
using System.Collections.Generic;
using System.Text;

namespace Selene.Core
{
    public abstract class DisposeableObject : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposeableObject()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                OnReleasingManagedResource();
            }

            OnReleasingUnmanagedResource();
        }

        protected virtual void OnReleasingManagedResource() { }
        protected virtual void OnReleasingUnmanagedResource() { }


    }
}
