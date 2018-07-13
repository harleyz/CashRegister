using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    [MetadataType(typeof(DiscountTransactionExtend))]
    public partial class DiscountTransaction : IEntityFramework
    {

    }

    public partial class DiscountTransactionExtend
    {
        public int Id { get; set; }
        public System.DateTime Time { get; set; }
        public int ReceiptId { get; set; }
        public int DiscountId { get; set; }
        public int ItemId { get; set; }
    }
}