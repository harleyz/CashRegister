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
    
    public partial class DiscountTransaction
    {
        public int Id { get; set; }
        public System.DateTime Time { get; set; }
        public int ReceiptId { get; set; }
        public int DiscountId { get; set; }
        public Nullable<int> ItemId { get; set; }
    
        public virtual Discount Discount { get; set; }
        public virtual Item Item { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
