using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    [Table("DemoSalesOrderDetailSeed", Schema = "Demo")]
    public partial class DemoSalesOrderDetailSeed
    {
        public short OrderQty { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("SpecialOfferID")]
        public int SpecialOfferId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("LocalID")]
        public int LocalId { get; set; }
    }
}
