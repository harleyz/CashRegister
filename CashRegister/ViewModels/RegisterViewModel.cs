using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    [MetadataType(typeof(RegisterExtend))]
    public partial class Register : IEntityFramework
    {

    }

    public partial class RegisterExtend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}