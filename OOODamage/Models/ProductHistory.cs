//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OOODamage.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductHistory
    {
        public int IdProductHistory { get; set; }
        public Nullable<int> IdProduct { get; set; }
        public Nullable<int> IdClientService { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual ClientService ClientService { get; set; }
        public virtual Product Product { get; set; }
    }
}
