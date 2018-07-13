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
        ReceiptRepository recieptRepo = null;

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
            recieptRepo = new ReceiptRepository(receiptId);
            decimal total = recieptRepo.DecimalTotal();
            decimal discountTotal = 0.0m;
            decimal newTotal = 0.0m;
            var discountTransactions = unitOfWork.DiscountTransactions.Get(t => t.ReceiptId == receiptId, null, "Discount").ToList();

            foreach (var discountTransaction in discountTransactions)
            {
                if(discountTransaction.Discount.Percent != null)
                {
                    //calc the amount off for percent
                    discountTotal += total * (discountTransaction.Discount.Percent.Value * 0.01m);
                }
                else if (discountTransaction.Discount.BuyX != null && discountTransaction.Discount.FreeY != null && discountTransaction.Discount.ItemId != null)
                {
                    //calc the amount off for items
                    discountTotal += (discountTransaction.Discount.FreeY.Value / discountTransaction.Discount.Item.QuanityOfMeasure) * discountTransaction.Discount.Item.Cost;
                }
            }

            newTotal = total - discountTotal;

            return "Previous Total = " + total + " New Total = " + newTotal + " Discount Total = " + discountTotal.ToString();
        }        

        public void Save()
        {
            unitOfWork.Context.SaveChanges();
        }

    }
}