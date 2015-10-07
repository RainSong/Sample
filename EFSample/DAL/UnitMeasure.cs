namespace EFSample.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.UnitMeasure")]
    public partial class UnitMeasure
    {
        public UnitMeasure()
        {
            BillOfMaterials = new HashSet<BillOfMaterials>();
            Product = new HashSet<Product>();
            Product1 = new HashSet<Product>();
            ProductVendor = new HashSet<ProductVendor>();
        }

        [Key]
        [StringLength(3)]
        public string UnitMeasureCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BillOfMaterials> BillOfMaterials { get; set; }

        public virtual ICollection<Product> Product { get; set; }

        public virtual ICollection<Product> Product1 { get; set; }

        public virtual ICollection<ProductVendor> ProductVendor { get; set; }
    }
}
