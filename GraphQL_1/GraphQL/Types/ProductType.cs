﻿using GraphQL.Types;
using GraphQL_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.ProductId);
            Field(x => x.Name);
            Field(x => x.MakeFlag, nullable: true);
            Field(x => x.FinishedGoodsFlag, nullable: true);
            Field(x => x.ProductNumber);
            Field(x => x.Color, nullable: true);
            Field<ListGraphType<TransactionHistoryType>>(nameof(Product.TransactionHistory));
        }
    }
}
