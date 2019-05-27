using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    [Table("OrderTracking", Schema = "Sales")]
    public partial class OrderTracking
    {
        [Column("OrderTrackingID")]
        public int OrderTrackingId { get; set; }
        [Column("SalesOrderID")]
        public int SalesOrderId { get; set; }
        [StringLength(25)]
        public string CarrierTrackingNumber { get; set; }
        [Column("TrackingEventID")]
        public int TrackingEventId { get; set; }
        [Required]
        [StringLength(2000)]
        public string EventDetails { get; set; }
        public DateTime EventDateTime { get; set; }
    }
}
