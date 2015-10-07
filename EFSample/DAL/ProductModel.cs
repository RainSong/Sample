namespace EFSample.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.ProductModel")]
    public partial class ProductModel
    {
        public ProductModel()
        {
            Product = new HashSet<Product>();
            ProductModelIllustration = new HashSet<ProductModelIllustration>();
            ProductModelProductDescriptionCulture = new HashSet<ProductModelProductDescriptionCulture>();
        }

        public int ProductModelID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "xml")]
        public string CatalogDescription { get; set; }

        [Column(TypeName = "xml")]
        public string Instructions { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Product> Product { get; set; }

        public virtual ICollection<ProductModelIllustration> ProductModelIllustration { get; set; }

        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; }
    }
}
