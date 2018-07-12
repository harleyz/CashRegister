using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegister.Models
{
    public class UnitOfWork : IDisposable
    {
        private Entities context = new Entities();
        private EntityFrameworkRepository<Item> itemRepo;
        private EntityFrameworkRepository<Register> registerRepo;
        private EntityFrameworkRepository<Transaction> transactionRepo;
        private EntityFrameworkRepository<Receipt> receiptRepo;
        

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

        public EntityFrameworkRepository<Register> Registers
        {
            get
            {
                if (registerRepo == null)
                {
                    registerRepo = new EntityFrameworkRepository<Register>(context);
                }
                return registerRepo;
            }
        }

        public EntityFrameworkRepository<Transaction> Transactions
        {
            get
            {
                if (transactionRepo == null)
                {
                    transactionRepo = new EntityFrameworkRepository<Transaction>(context);
                }
                return transactionRepo;
            }
        }

        public EntityFrameworkRepository<Receipt> Receipts
        {
            get
            {
                if (receiptRepo == null)
                {
                    receiptRepo = new EntityFrameworkRepository<Receipt>(context);
                }
                return receiptRepo;
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