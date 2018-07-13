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

        public DiscountTransaction New(int receiptId, int discountId, int? itemId = null)
        {
            DiscountTransaction discountTransaction = new DiscountTransaction() { ReceiptId = receiptId, DiscountId = discountId, ItemId = itemId, Time = DateTime.Now };
            unitOfWork.DiscountTransactions.Insert(discountTransaction);
            Save();

            return discountTransaction;
        }

        public string WriteTotal(int receiptId)
        {
            decimal total = 0.0m;
            var discountTransactions = unitOfWork.DiscountTransactions.Get(t => t.ReceiptId == receiptId).ToList();

            foreach (var discountTransaction in discountTransactions)
            {
                if(discountTransaction.Discount.Percent != null)
                {
                    //get receipt total minus percent
                }
                else
                {
                    //calc the amount off for items
                    //total = total + ((transaction.Quantity / transaction.Item.QuanityOfMeasure) * transaction.Item.Cost);
                }

            }

            return total.ToString();
        }
        

        public void Save()
        {
            unitOfWork.Context.SaveChanges();
        }

    }
}