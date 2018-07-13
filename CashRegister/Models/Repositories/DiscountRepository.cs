﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;

namespace CashRegister.Models.Repositories
{
    public class DiscountRepository
    {
        private UnitOfWork unitOfWork;
        public Discount _discount = null;

        public DiscountRepository()
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

        public Discount Get(Guid SKU, string includeProperties = "")
        {
            return unitOfWork.Discounts.Get(t => t.SKU == SKU, includeProperties: includeProperties, orderBy: o => o.OrderByDescending(order => order.Id)).FirstOrDefault();
        }

        public Discount Get(string code, string includeProperties = "")
        {
            return unitOfWork.Discounts.Get(t => t.Code == code, includeProperties: includeProperties, orderBy: o => o.OrderByDescending(order => order.Id)).FirstOrDefault();
        }


        public void Find(string input)
        {
            if (Guid.TryParse(input, out Guid newOutGuid))
            {
                _discount = Get(newOutGuid);
            }
            else
            {
                _discount = Get(input);
            }
        }

        public void SeedData()
        {
            var discounts = UnitOfWork.Discounts.Get();
            if (discounts.Count() < 1)
            {

                var applesItem = UnitOfWork.Items.Get(t => t.ProductName.Equals("Apples")).FirstOrDefault();
                var orangesItem = UnitOfWork.Items.Get(t => t.ProductName.Equals("Oranges")).FirstOrDefault();

                var listOfDiscounts = new List<Discount>
                {
                    new Discount() { Code = "3APPLES1FREE", SKU = Guid.NewGuid(), BuyX = 3, FreeY = 1, ItemId = applesItem.Id},
                    new Discount() { Code = "2ORANGES2FREE", SKU = Guid.NewGuid(), BuyX = 2, FreeY = 2, ItemId = orangesItem.Id},
                    new Discount() { Code = "20PERCENT", SKU = Guid.NewGuid(), Percent = 20 }
                };

                foreach (var discount in listOfDiscounts)
                {
                    unitOfWork.Discounts.Insert(discount);
                    Save();
                }
            }
        }

        public void Save()
        {
            unitOfWork.Context.SaveChanges();
        }

    }
}