namespace EFSample.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HumanResources.Employee")]
    public partial class Employee
    {
        public Employee()
        {
            EmployeeDepartmentHistory = new HashSet<EmployeeDepartmentHistory>();
            EmployeePayHistory = new HashSet<EmployeePayHistory>();
            JobCandidate = new HashSet<JobCandidate>();
            PurchaseOrderHeader = new HashSet<PurchaseOrderHeader>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        [Required]
        [StringLength(15)]
        public string NationalIDNumber { get; set; }

        [Required]
        [StringLength(256)]
        public string LoginID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public short? OrganizationLevel { get; set; }

        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(1)]
        public string MaritalStatus { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime HireDate { get; set; }

        public bool SalariedFlag { get; set; }

        public short VacationHours { get; set; }

        public short SickLeaveHours { get; set; }

        public bool CurrentFlag { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }

        public virtual ICollection<EmployeePayHistory> EmployeePayHistory { get; set; }

        public virtual ICollection<JobCandidate> JobCandidate { get; set; }

        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }

        public virtual SalesPerson SalesPerson { get; set; }
    }
}
