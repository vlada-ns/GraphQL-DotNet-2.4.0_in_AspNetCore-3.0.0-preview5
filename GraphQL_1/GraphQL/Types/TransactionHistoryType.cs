using GraphQL.Types;
using GraphQL_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.GraphQL.Types
{
    public class TransactionHistoryType : ObjectGraphType<TransactionHistory>
    {
        public TransactionHistoryType()
        {
            Field(x => x.TransactionId);
            Field(x => x.ReferenceOrderId);
            Field(x => x.ReferenceOrderLineId);
            Field(x => x.TransactionDate);
            Field(x => x.TransactionType);
            Field(x => x.Quantity);
            Field(x => x.ActualCost);
            Field(x => x.ModifiedDate);
            Field<ProductType>(nameof(TransactionHistory.Product));
        }
    }
}