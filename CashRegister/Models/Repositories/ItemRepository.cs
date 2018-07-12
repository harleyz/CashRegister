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
        public enum UnitOfMeasure
        {
            POUNDS = 1,
            OUNCES = 2,
            ITEM = 3
        }

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

        public void SeedData()
        {
            var items = UnitOfWork.Items.Get();
            if (items.Count() < 1)
            {
                var listOfItems = new List<Item>
                {
                    new Item() { ProductName = "Pears", SKU = Guid.NewGuid(), UnitOfMeasure = (int)UnitOfMeasure.POUNDS, Cost = 0.67m, QuanityOfMeasure = 1.0m },
                    new Item() { ProductName = "Bannanas", SKU = Guid.NewGuid(), UnitOfMeasure = (int)UnitOfMeasure.POUNDS, Cost = 1.67m, QuanityOfMeasure = 1.0m },
                    new Item() { ProductName = "PineApples", SKU = Guid.NewGuid(), UnitOfMeasure = (int)UnitOfMeasure.POUNDS, Cost = 0.99m, QuanityOfMeasure = 1.0m },
                    new Item() { ProductName = "Apples", SKU = Guid.NewGuid(), UnitOfMeasure = (int)UnitOfMeasure.POUNDS, Cost = 2.00m, QuanityOfMeasure = 1.0m },
                    new Item() { ProductName = "Oranges", SKU = Guid.NewGuid(), UnitOfMeasure = (int)UnitOfMeasure.POUNDS, Cost = 0.23m, QuanityOfMeasure = 1.0m },
                    new Item() { ProductName = "Pear Pizza", SKU = Guid.NewGuid(), UnitOfMeasure = (int)UnitOfMeasure.ITEM, Cost = 9.99m, QuanityOfMeasure = 1.0m },
                    new Item() { ProductName = "Bannana Pizza", SKU = Guid.NewGuid(), UnitOfMeasure = (int)UnitOfMeasure.ITEM, Cost = 9.99m, QuanityOfMeasure = 1.0m },
                    new Item() { ProductName = "PineApple Pizza", SKU = Guid.NewGuid(), UnitOfMeasure = (int)UnitOfMeasure.ITEM, Cost = 9.99m, QuanityOfMeasure = 1.0m },
                    new Item() { ProductName = "Apple Pizza", SKU = Guid.NewGuid(), UnitOfMeasure = (int)UnitOfMeasure.ITEM, Cost = 9.99m, QuanityOfMeasure = 1.0m },
                    new Item() { ProductName = "Orange Pizza", SKU = Guid.NewGuid(), UnitOfMeasure = (int)UnitOfMeasure.ITEM, Cost = 9.99m, QuanityOfMeasure = 1.0m }
                };

                foreach (var item in listOfItems)
                {
                    unitOfWork.Items.Insert(item);
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