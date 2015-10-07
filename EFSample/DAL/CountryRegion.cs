namespace EFSample.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person.CountryRegion")]
    public partial class CountryRegion
    {
        public CountryRegion()
        {
            CountryRegionCurrency = new HashSet<CountryRegionCurrency>();
            SalesTerritory = new HashSet<SalesTerritory>();
            StateProvince = new HashSet<StateProvince>();
        }

        [Key]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrency { get; set; }

        public virtual ICollection<SalesTerritory> SalesTerritory { get; set; }

        public virtual ICollection<StateProvince> StateProvince { get; set; }
    }
}
