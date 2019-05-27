using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    [Table("SalesOrderHeader_ondisk", Schema = "Sales")]
    public partial class SalesOrderHeaderOndisk
    {
        public SalesOrderHeaderOndisk()
        {
            SalesOrderDetailOndisk = new HashSet<SalesOrderDetailOndisk>();
        }

        [Column("SalesOrderID")]
        public int SalesOrderId { get; set; }
        public byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public byte Status { get; set; }
        [Required]
        public bool? OnlineOrderFlag { get; set; }
        [StringLength(25)]
        public string PurchaseOrderNumber { get; set; }
        [StringLength(15)]
        public string AccountNumber { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("SalesPersonID")]
        public int SalesPersonId { get; set; }
        [Column("TerritoryID")]
        public int? TerritoryId { get; set; }
        [Column("BillToAddressID")]
        public int BillToAddressId { get; set; }
        [Column("ShipToAddressID")]
        public int ShipToAddressId { get; set; }
        [Column("ShipMethodID")]
        public int ShipMethodId { get; set; }
        [Column("CreditCardID")]
        public int? CreditCardId { get; set; }
        [StringLength(15)]
        public string CreditCardApprovalCode { get; set; }
        [Column("CurrencyRateID")]
        public int? CurrencyRateId { get; set; }
        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal TaxAmt { get; set; }
        [Column(TypeName = "money")]
        public decimal Freight { get; set; }
        [StringLength(128)]
        public string Comment { get; set; }
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("SalesOrder")]
        public virtual ICollection<SalesOrderDetailOndisk> SalesOrderDetailOndisk { get; set; }
    }
}
