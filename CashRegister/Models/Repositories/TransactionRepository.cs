using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;

namespace CashRegister.Models.Repositories
{
    public class TransactionRepository
    {
        private UnitOfWork unitOfWork;

        public TransactionRepository()
        {
            unitOfWork = new UnitOfWork();
        }

        public UnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public Transaction Get(int Id, string includeProperties = "")
        {
            return unitOfWork.Transactions.Get(t => t.Id == Id, includeProperties: includeProperties, orderBy: o => o.OrderByDescending(order => order.Id)).FirstOrDefault();
        }

        public void Save()
        {
            unitOfWork.Context.SaveChanges();
        }

    }
}