namespace EFSample.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person.Address")]
    public partial class Address
    {
        public Address()
        {
            BusinessEntityAddress = new HashSet<BusinessEntityAddress>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
            SalesOrderHeader1 = new HashSet<SalesOrderHeader>();
        }

        public int AddressID { get; set; }

        [Required]
        [StringLength(60)]
        public string AddressLine1 { get; set; }

        [StringLength(60)]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        public int StateProvinceID { get; set; }

        [Required]
        [StringLength(15)]
        public string PostalCode { get; set; }

        public DbGeography SpatialLocation { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual StateProvince StateProvince { get; set; }

        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddress { get; set; }

        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }

        public virtual ICollection<SalesOrderHeader> SalesOrderHeader1 { get; set; }
    }
}
