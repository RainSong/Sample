namespace EFSample.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.SalesTerritory")]
    public partial class SalesTerritory
    {
        public SalesTerritory()
        {
            StateProvince = new HashSet<StateProvince>();
            Customer = new HashSet<Customer>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
            SalesPerson = new HashSet<SalesPerson>();
            SalesTerritoryHistory = new HashSet<SalesTerritoryHistory>();
        }

        [Key]
        public int TerritoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Group { get; set; }

        [Column(TypeName = "money")]
        public decimal SalesYTD { get; set; }

        [Column(TypeName = "money")]
        public decimal SalesLastYear { get; set; }

        [Column(TypeName = "money")]
        public decimal CostYTD { get; set; }

        [Column(TypeName = "money")]
        public decimal CostLastYear { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual CountryRegion CountryRegion { get; set; }

        public virtual ICollection<StateProvince> StateProvince { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }

        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }

        public virtual ICollection<SalesPerson> SalesPerson { get; set; }

        public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistory { get; set; }
    }
}
