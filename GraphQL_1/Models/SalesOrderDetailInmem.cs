using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    [Table("SalesOrderDetail_inmem", Schema = "Sales")]
    public partial class SalesOrderDetailInmem
    {
        [Column("SalesOrderID")]
        public int SalesOrderId { get; set; }
        [Column("SalesOrderDetailID")]
        public long SalesOrderDetailId { get; set; }
        [StringLength(25)]
        public string CarrierTrackingNumber { get; set; }
        public short OrderQty { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("SpecialOfferID")]
        public int SpecialOfferId { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPriceDiscount { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("SalesOrderId")]
        [InverseProperty("SalesOrderDetailInmem")]
        public virtual SalesOrderHeaderInmem SalesOrder { get; set; }
        [ForeignKey("SpecialOfferId,ProductId")]
        [InverseProperty("SalesOrderDetailInmem")]
        public virtual SpecialOfferProductInmem SpecialOfferProductInmem { get; set; }
    }
}
