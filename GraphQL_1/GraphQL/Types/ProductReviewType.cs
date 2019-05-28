using GraphQL.Types;
using GraphQL_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.GraphQL.Types
{
    public class ProductReviewType : ObjectGraphType<ProductReview>
    {
        public ProductReviewType()
        {
            Field(x => x.ProductReviewId);
            Field(x => x.ReviewerName);
            Field(x => x.ReviewDate);
            Field(x => x.EmailAddress);
            Field(x => x.Rating);
            Field(x => x.Comments);
            Field(x => x.ModifiedDate);
            Field<ProductType>(nameof(ProductReview.Product));
        }
    }
}
