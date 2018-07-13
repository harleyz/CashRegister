using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    [MetadataType(typeof(DiscountExtend))]
    public partial class Discount : IEntityFramework
    {

    }

    public partial class DiscountExtend
    {
        public int Id { get; set; }
        public System.Guid SKU { get; set; }
        public Nullable<int> Percent { get; set; }
        public Nullable<int> BuyX { get; set; }
        public Nullable<int> FreeY { get; set; }
        public string Code { get; set; }
        public int ItemId { get; set; }
    }
}