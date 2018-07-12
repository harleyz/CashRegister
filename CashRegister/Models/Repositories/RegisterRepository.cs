using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;

namespace CashRegister.Models.Repositories
{
    public class RegisterRepository
    {
        private UnitOfWork unitOfWork;
        public Register _register;

        public RegisterRepository()
        {
            unitOfWork = new UnitOfWork();
            SeedData();
        }

        public UnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public Register Get(int Id, string includeProperties = "")
        {
            return unitOfWork.Registers.Get(t => t.Id == Id, includeProperties: includeProperties, orderBy: o => o.OrderByDescending(order => order.Id)).FirstOrDefault();
        }

        public void SeedData()
        {
            var registers = UnitOfWork.Registers.Get();
            if (registers.Count() < 1)
            {
                var register = new Register() { Name = "The Orginal", Location = "Smart Engergy Water" };
                unitOfWork.Registers.Insert(register);
                Save();
            }

            _register = UnitOfWork.Registers.Get().FirstOrDefault();
        }

        public void Save()
        {
            unitOfWork.Context.SaveChanges();
        }

    }
}