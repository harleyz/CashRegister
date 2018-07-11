using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;

namespace CashRegister.Models.Repositories
{
    public class ItemRepository
    {
        private UnitOfWork unitOfWork;

        public ItemRepository()
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

        public Item GetItem(Guid SKU, string includeProperties = "")
        {
            return unitOfWork.Items.Get(t => t.SKU == SKU, includeProperties: includeProperties, orderBy: o => o.OrderByDescending(order => order.Id)).FirstOrDefault();
        }

    }
}