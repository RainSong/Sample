namespace EFSample.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.Product")]
    public partial class Product
    {
        public Product()
        {
            BillOfMaterials = new HashSet<BillOfMaterials>();
            BillOfMaterials1 = new HashSet<BillOfMaterials>();
            ProductCostHistory = new HashSet<ProductCostHistory>();
            ProductInventory = new HashSet<ProductInventory>();
            ProductListPriceHistory = new HashSet<ProductListPriceHistory>();
            ProductProductPhoto = new HashSet<ProductProductPhoto>();
            ProductReview = new HashSet<ProductReview>();
            ProductVendor = new HashSet<ProductVendor>();
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
            SpecialOfferProduct = new HashSet<SpecialOfferProduct>();
            TransactionHistory = new HashSet<TransactionHistory>();
            WorkOrder = new HashSet<WorkOrder>();
        }

        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string ProductNumber { get; set; }

        public bool MakeFlag { get; set; }

        public bool FinishedGoodsFlag { get; set; }

        [StringLength(15)]
        public string Color { get; set; }

        public short SafetyStockLevel { get; set; }

        public short ReorderPoint { get; set; }

        [Column(TypeName = "money")]
        public decimal StandardCost { get; set; }

        [Column(TypeName = "money")]
        public decimal ListPrice { get; set; }

        [StringLength(5)]
        public string Size { get; set; }

        [StringLength(3)]
        public string SizeUnitMeasureCode { get; set; }

        [StringLength(3)]
        public string WeightUnitMeasureCode { get; set; }

        public decimal? Weight { get; set; }

        public int DaysToManufacture { get; set; }

        [StringLength(2)]
        public string ProductLine { get; set; }

        [StringLength(2)]
        public string Class { get; set; }

        [StringLength(2)]
        public string Style { get; set; }

        public int? ProductSubcategoryID { get; set; }

        public int? ProductModelID { get; set; }

        public DateTime SellStartDate { get; set; }

        public DateTime? SellEndDate { get; set; }

        public DateTime? DiscontinuedDate { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BillOfMaterials> BillOfMaterials { get; set; }

        public virtual ICollection<BillOfMaterials> BillOfMaterials1 { get; set; }

        public virtual ProductModel ProductModel { get; set; }

        public virtual ProductSubcategory ProductSubcategory { get; set; }

        public virtual UnitMeasure UnitMeasure { get; set; }

        public virtual UnitMeasure UnitMeasure1 { get; set; }

        public virtual ICollection<ProductCostHistory> ProductCostHistory { get; set; }

        public virtual ProductDocument ProductDocument { get; set; }

        public virtual ICollection<ProductInventory> ProductInventory { get; set; }

        public virtual ICollection<ProductListPriceHistory> ProductListPriceHistory { get; set; }

        public virtual ICollection<ProductProductPhoto> ProductProductPhoto { get; set; }

        public virtual ICollection<ProductReview> ProductReview { get; set; }

        public virtual ICollection<ProductVendor> ProductVendor { get; set; }

        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }

        public virtual ICollection<SpecialOfferProduct> SpecialOfferProduct { get; set; }

        public virtual ICollection<TransactionHistory> TransactionHistory { get; set; }

        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
    }
}
