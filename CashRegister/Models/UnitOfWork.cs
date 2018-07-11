using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegister.Models
{
    public class UnitOfWork : IDisposable
    {
        private Entities context = new Entities();
        private EntityFrameworkRepository<Item> itemRepo;

        public Entities Context { get { return context; } }

        public EntityFrameworkRepository<Item> Items
        {
            get
            {
                if (itemRepo == null)
                {
                    itemRepo = new EntityFrameworkRepository<Item>(context);
                }
                return itemRepo;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}