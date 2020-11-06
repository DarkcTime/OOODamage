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
    
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            this.ClientServices = new HashSet<ClientService>();
            this.EmpServices = new HashSet<EmpService>();
        }
    
        public int IdService { get; set; }
        public string NameService { get; set; }
        public string Decription { get; set; }
        public decimal Price { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public int TimeDuration { get; set; }
        public Nullable<int> IdMainImage { get; set; }
        public Nullable<bool> IsOppositeGender { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientService> ClientServices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpService> EmpServices { get; set; }
    }
}
