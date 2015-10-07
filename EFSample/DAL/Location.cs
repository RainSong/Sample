namespace EFSample.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.Location")]
    public partial class Location
    {
        public Location()
        {
            ProductInventory = new HashSet<ProductInventory>();
            WorkOrderRouting = new HashSet<WorkOrderRouting>();
        }

        public short LocationID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal CostRate { get; set; }

        public decimal Availability { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductInventory> ProductInventory { get; set; }

        public virtual ICollection<WorkOrderRouting> WorkOrderRouting { get; set; }
    }
}
