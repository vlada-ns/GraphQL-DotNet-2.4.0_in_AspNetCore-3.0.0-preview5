using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    public partial class AspNetUserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("AspNetUserRoles")]
        public virtual AspNetRoles Role { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("AspNetUserRoles")]
        public virtual AspNetUsers User { get; set; }
    }
}
