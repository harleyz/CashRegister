//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CashRegister.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int Id { get; set; }
        public int Item { get; set; }
        public decimal Quantity { get; set; }
        public System.DateTime Time { get; set; }
        public int ItemId { get; set; }
        public int ReceiptId { get; set; }
    
        public virtual Item Item1 { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
