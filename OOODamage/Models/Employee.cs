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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.EmpServices = new HashSet<EmpService>();
        }
    
        public int IdEmployee { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int Serial { get; set; }
        public int Number { get; set; }
        public int DivCode { get; set; }
        public string IdGender { get; set; }
        public decimal Coef { get; set; }
        public System.DateTime BithDate { get; set; }
        public int IdCategory { get; set; }
    
        public virtual CategoryEmployee CategoryEmployee { get; set; }
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpService> EmpServices { get; set; }
    }
}
