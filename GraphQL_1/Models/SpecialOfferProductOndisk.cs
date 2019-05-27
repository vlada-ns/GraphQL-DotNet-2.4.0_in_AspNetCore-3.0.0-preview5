using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_1.Models
{
    [Table("SpecialOfferProduct_ondisk", Schema = "Sales")]
    public partial class SpecialOfferProductOndisk
    {
        public SpecialOfferProductOndisk()
        {
            SalesOrderDetailOndisk = new HashSet<SalesOrderDetailOndisk>();
        }

        [Column("SpecialOfferID")]
        public int SpecialOfferId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("SpecialOfferProductOndisk")]
        public virtual ProductOndisk Product { get; set; }
        [ForeignKey("SpecialOfferId")]
        [InverseProperty("SpecialOfferProductOndisk")]
        public virtual SpecialOfferOndisk SpecialOffer { get; set; }
        [InverseProperty("SpecialOfferProductOndisk")]
        public virtual ICollection<SalesOrderDetailOndisk> SalesOrderDetailOndisk { get; set; }
    }
}
