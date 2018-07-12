using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using static CashRegister.Models.Repositories.ItemRepository;

namespace CashRegister.Models.Repositories
{
    public class ReceiptRepository
    {
        private UnitOfWork unitOfWork;
        RegisterRepository registerRepo;
        public Receipt _receipt;
        

        public ReceiptRepository()
        {
            unitOfWork = new UnitOfWork();
            New();
        }

        public UnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public Receipt Get(int Id, string includeProperties = "")
        {
            return unitOfWork.Receipts.Get(t => t.Id == Id, includeProperties: includeProperties, orderBy: o => o.OrderByDescending(order => order.Id)).FirstOrDefault();
        }

        public void New()
        {
            registerRepo = new RegisterRepository();

            var receipt = new Receipt() { RegisterId = registerRepo._register.Id, Time = DateTime.Now };
            unitOfWork.Receipts.Insert(receipt);
            Save();
            _receipt = receipt;
        }

        public string WriteList()
        {
            var transactions = unitOfWork.Transactions.Get(t => t.ReceiptId == _receipt.Id).ToList();

            return string.Join("\r\n ", transactions.Select(t => t.Item.ProductName + " x " + t.Quantity + " " + Enum.GetName(typeof(UnitOfMeasure), t.Item.UnitOfMeasure)).ToList());
        }

        public string Total()
        {
            decimal total = 0.0m;

            var transactions = unitOfWork.Transactions.Get(t => t.ReceiptId == _receipt.Id).ToList();

            foreach(var transaction in transactions)
            {
                total = total + ((transaction.Quantity / transaction.Item.QuanityOfMeasure) * transaction.Item.Cost);
            }

            return total.ToString();
        }

        public void Save()
        {
            unitOfWork.Context.SaveChanges();
        }
    }
}