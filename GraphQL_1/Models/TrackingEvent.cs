using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    [Table("TrackingEvent", Schema = "Sales")]
    public partial class TrackingEvent
    {
        [Column("TrackingEventID")]
        public int TrackingEventId { get; set; }
        [Required]
        [StringLength(255)]
        public string EventName { get; set; }
    }
}
