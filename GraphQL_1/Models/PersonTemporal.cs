using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    [Table("Person_Temporal", Schema = "Person")]
    public partial class PersonTemporal
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Required]
        [StringLength(2)]
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        [StringLength(8)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(10)]
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }
    }
}
