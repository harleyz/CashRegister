using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    [MetadataType(typeof(ItemExtend))]
    public partial class Item : IEntityFramework
    {

    }

    public partial class ItemExtend
    {
        public int Id { get; set; }
        public System.Guid SKU { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public int UnitOfMeasure { get; set; }
        public decimal QuanityOfMeasure { get; set; }
    }
}