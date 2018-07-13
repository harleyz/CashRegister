using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;

namespace CashRegister.Models.Repositories
{
    public class DiscountTransactionRepository
    {
        private UnitOfWork unitOfWork;

        public DiscountTransactionRepository()
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

        public DiscountTransaction Get(int Id, string includeProperties = "")
        {
            return unitOfWork.DiscountTransactions.Get(t => t.Id == Id, includeProperties: includeProperties, orderBy: o => o.OrderByDescending(order => order.Id)).FirstOrDefault();
        }

        public DiscountTransaction New(int receiptId, int discountId, decimal quantity)
        {
            DiscountTransaction discountTransaction = new DiscountTransaction() { ReceiptId = receiptId, DiscountId = discountId, Time = DateTime.Now };
            unitOfWork.DiscountTransactions.Insert(discountTransaction);
            Save();

            return discountTransaction;
        }

        public void Save()
        {
            unitOfWork.Context.SaveChanges();
        }

    }
}