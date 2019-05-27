using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    [Table("Employee_Temporal", Schema = "HumanResources")]
    public partial class EmployeeTemporal
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Required]
        [Column("NationalIDNumber")]
        [StringLength(15)]
        public string NationalIdnumber { get; set; }
        [Required]
        [Column("LoginID")]
        [StringLength(256)]
        public string LoginId { get; set; }
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
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
    }
}
