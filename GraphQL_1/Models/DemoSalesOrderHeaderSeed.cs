using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    [Table("DemoSalesOrderHeaderSeed", Schema = "Demo")]
    public partial class DemoSalesOrderHeaderSeed
    {
        public DateTime DueDate { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("SalesPersonID")]
        public int SalesPersonId { get; set; }
        [Column("BillToAddressID")]
        public int BillToAddressId { get; set; }
        [Column("ShipToAddressID")]
        public int ShipToAddressId { get; set; }
        [Column("ShipMethodID")]
        public int ShipMethodId { get; set; }
        [Column("LocalID")]
        public int LocalId { get; set; }
    }
}
