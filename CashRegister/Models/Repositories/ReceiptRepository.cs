using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;

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

        public void Save()
        {
            unitOfWork.Context.SaveChanges();
        }
    }
}