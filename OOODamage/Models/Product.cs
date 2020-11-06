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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductHistories = new HashSet<ProductHistory>();
            this.ProductOnWareHouses = new HashSet<ProductOnWareHouse>();
            this.ProductParents = new HashSet<ProductParent>();
            this.ProductParents1 = new HashSet<ProductParent>();
        }
    
        public int idProduct { get; set; }
        public string NameProduct { get; set; }
        public int IdProdCategory { get; set; }
        public decimal Price { get; set; }
        public string Specifications { get; set; }
        public string Decription { get; set; }
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Lenght { get; set; }
        public int IdManufacturer { get; set; }
        public int IdMainImage { get; set; }
        public bool IsActual { get; set; }
        public int IdSeason { get; set; }
        public int IdProductPhoto { get; set; }
    
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductPhoto ProductPhoto { get; set; }
        public virtual Season Season { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductHistory> ProductHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOnWareHouse> ProductOnWareHouses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductParent> ProductParents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductParent> ProductParents1 { get; set; }
    }
}