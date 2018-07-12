using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    [MetadataType(typeof(ReceiptExtend))]
    public partial class Receipt : IEntityFramework
    {

    }

    public partial class ReceiptExtend
    {
        public int Id { get; set; }
        public int RegisterId { get; set; }
        public System.DateTime Time { get; set; }
    }
}