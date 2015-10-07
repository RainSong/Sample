namespace EFSample.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.SalesPerson")]
    public partial class SalesPerson
    {
        public SalesPerson()
        {
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
            SalesPersonQuotaHistory = new HashSet<SalesPersonQuotaHistory>();
            SalesTerritoryHistory = new HashSet<SalesTerritoryHistory>();
            Store = new HashSet<Store>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        public int? TerritoryID { get; set; }

        [Column(TypeName = "money")]
        public decimal? SalesQuota { get; set; }

        [Column(TypeName = "money")]
        public decimal Bonus { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal CommissionPct { get; set; }

        [Column(TypeName = "money")]
        public decimal SalesYTD { get; set; }

        [Column(TypeName = "money")]
        public decimal SalesLastYear { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }

        public virtual SalesTerritory SalesTerritory { get; set; }

        public virtual ICollection<SalesPersonQuotaHistory> SalesPersonQuotaHistory { get; set; }

        public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistory { get; set; }

        public virtual ICollection<Store> Store { get; set; }
    }
}
