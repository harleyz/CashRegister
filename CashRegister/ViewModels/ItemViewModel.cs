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
    }
}