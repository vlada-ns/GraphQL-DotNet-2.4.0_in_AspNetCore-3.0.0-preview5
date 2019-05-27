using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    [Table("SalesOrderDetail_ondisk", Schema = "Sales")]
    public partial class SalesOrderDetailOndisk
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
        [InverseProperty("SalesOrderDetailOndisk")]
        public virtual SalesOrderHeaderOndisk SalesOrder { get; set; }
        [ForeignKey("SpecialOfferId,ProductId")]
        [InverseProperty("SalesOrderDetailOndisk")]
        public virtual SpecialOfferProductOndisk SpecialOfferProductOndisk { get; set; }
    }
}
