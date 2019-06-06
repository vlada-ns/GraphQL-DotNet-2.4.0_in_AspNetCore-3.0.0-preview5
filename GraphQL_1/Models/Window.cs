using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    public class Window
    {
        public int WindowId { get; set; }
        public string Name { get; set; }

        //[Column("HouseId")]
        public int HouseId { get; set; }

        [ForeignKey("HouseId")]
        [InverseProperty("Windows")]
        public virtual House House { get; set; }
    }
}