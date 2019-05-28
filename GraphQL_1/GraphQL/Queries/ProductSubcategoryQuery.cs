//using GraphQL.Types;
//using GraphQL_1.GraphQL.Types;
//using GraphQL_1.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GraphQL_1.GraphQL.Queries
//{
//    public class ProductSubcategoryQuery : ObjectGraphType
//    {
//        public ProductSubcategoryQuery(ProductSubcategoryRepository productSubcategoryRepository)
//        {
//            /*
//             -- Simple test query --
//                query TestQuery {
//                    products(productId: 1) {
//                        productId: productId
//                        name,
//                        makeFlag,
//                        finishedGoodsFlag,
//                        productNumber,
//                        color
//                        transactionHistory{
//                            transactionId,
//                            transactionDate,
//                            transactionType,
//                            quantity,
//                            actualCost,
//                            modifiedDate
//                        }
//                    }
//                }
//            */

//            //Field<ListGraphType<ProductSubcategoryType>>(
//            //    "productSubcategories",
//            //    resolve: context => productSubcategoryRepository.GetAll());

//            /*Version: 2 filtering*/
//            Field<ListGraphType<ProductSubcategoryType>>(
//                "productSubcategories",
//                arguments: new QueryArguments(new List<QueryArgument>
//                {
//                    new QueryArgument<IdGraphType>
//                    {
//                        Name = "productSubcategoryId"
//                    },
//                    new QueryArgument<StringGraphType>
//                    {
//                        Name = "name"
//                    },
//                    new QueryArgument<IdGraphType>
//                    {
//                        Name = "Rowguid"
//                    },
//                    new QueryArgument<DateTimeGraphType>
//                    {
//                        Name = "ModifiedDate"
//                    }
//                }),
//                resolve: context =>
//                {
//                    var query = productSubcategoryRepository.GetAllAsync();
//                    return query;
//                }
//            );
//        }
//    }
//}
