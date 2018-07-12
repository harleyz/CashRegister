using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    [MetadataType(typeof(TransactionExtend))]
    public partial class Transaction : IEntityFramework
    {

    }

    public partial class TransactionExtend
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public System.DateTime Time { get; set; }
        public int ReceiptId { get; set; }
        public int ItemId { get; set; }
    }
}