namespace EFSample.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.Currency")]
    public partial class Currency
    {
        public Currency()
        {
            CountryRegionCurrency = new HashSet<CountryRegionCurrency>();
            CurrencyRate = new HashSet<CurrencyRate>();
            CurrencyRate1 = new HashSet<CurrencyRate>();
        }

        [Key]
        [StringLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrency { get; set; }

        public virtual ICollection<CurrencyRate> CurrencyRate { get; set; }

        public virtual ICollection<CurrencyRate> CurrencyRate1 { get; set; }
    }
}
