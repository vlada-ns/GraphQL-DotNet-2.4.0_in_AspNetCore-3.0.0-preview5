using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    [Table("SpecialOfferProduct_inmem", Schema = "Sales")]
    public partial class SpecialOfferProductInmem
    {
        public SpecialOfferProductInmem()
        {
            SalesOrderDetailInmem = new HashSet<SalesOrderDetailInmem>();
        }

        [Column("SpecialOfferID")]
        public int SpecialOfferId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("SpecialOfferProductInmem")]
        public virtual ProductInmem Product { get; set; }
        [ForeignKey("SpecialOfferId")]
        [InverseProperty("SpecialOfferProductInmem")]
        public virtual SpecialOfferInmem SpecialOffer { get; set; }
        [InverseProperty("SpecialOfferProductInmem")]
        public virtual ICollection<SalesOrderDetailInmem> SalesOrderDetailInmem { get; set; }
    }
}
