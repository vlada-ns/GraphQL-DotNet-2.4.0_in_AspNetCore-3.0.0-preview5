using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.Models
{
    public class House
    {
        public int HouseId { get; set; }
        public string Name { get; set; }

        [InverseProperty("House")]
        public /*virtual*/ ICollection<Window> Windows { get; set; }
    }
}
