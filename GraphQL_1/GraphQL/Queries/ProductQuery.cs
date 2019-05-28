//using GraphQL;
//using GraphQL.Types;
//using GraphQL_1.GraphQL.Types;
//using GraphQL_1.Models;
//using GraphQL_1.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace GraphQL_1.GraphQL.Queries
//{
//    public class ProductQuery : ObjectGraphType
//    {
//        public ProductQuery(ProductRepository productRepository)
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

//            //Field<ListGraphType<ProductType>>(
//            //    "products",
//            //    resolve: context => productRepository.GetAll());

//            /*Version: 2 filtering*/
//            Field<ListGraphType<ProductType>>(
//                "products",
//                arguments: new QueryArguments(new List<QueryArgument>
//                {
//                    new QueryArgument<IdGraphType>
//                    {
//                        Name = "productId"
//                    },
//                    new QueryArgument<ListGraphType<IdGraphType>>
//                    {
//                        Name = "productIds"
//                    },
//                    new QueryArgument<StringGraphType>
//                    {
//                        Name = "name"
//                    },
//                    new QueryArgument<BooleanGraphType>
//                    {
//                        Name = "makeFlag"
//                    },
//                    new QueryArgument<BooleanGraphType>
//                    {
//                        Name = "finishedGoodsFlag"
//                    },
//                    new QueryArgument<StringGraphType>
//                    {
//                        Name = "productNumber"
//                    },
//                    new QueryArgument<StringGraphType>
//                    {
//                        Name = "color"
//                    }/*,
//                    new QueryArgument<TransactionHistoryType>
//                    {
//                        Name = "transactionHistory"
//                    }*/
//                }),
//                resolve: context =>
//                {
//                    var query = productRepository.GetProductsAsync();
//                    //var query = productRepository.GetQuery();
//                    //var query = productRepository.GetAll();

//                    //var user = (ClaimsPrincipal)context.UserContext;
//                    //var isUserAuthenticated = ((ClaimsIdentity)user.Identity).IsAuthenticated;

//                    var productId = context.GetArgument<int?>("productId");
//                    if (productId.HasValue)
//                    {
//                        if (productId.Value <= 0)
//                        {
//                            context.Errors.Add(new ExecutionError("productId must be greater than zero!"));
//                            return new List<Product>();
//                        }
//                        List<int> listProductId = new List<int>();
//                        listProductId.Add(productId.Value);
//                        return productRepository.GetProductsAsync(listProductId);
//                    }

//                    var productIds = context.GetArgument<List<int?>>("productIds");
//                    if (productIds != null /*|| productIds.Any()*/)
//                    {
//                        List<int> listProductIds = new List<int>();
//                        listProductIds = productIds.Where(u => u != null)
//                            .Select(u => u.Value)
//                            .ToList();
//                        return productRepository.GetProductsAsync(listProductIds);
//                    }
//                    //if (productIds == null || !productIds.Any())
//                    //{
//                    //    List<int> intList = new List<int>();
//                    //    var tmp5 = productRepository.GetProductsAsync(new List<int>());
//                    //    return tmp5;
//                    //}

//                    var name = context.GetArgument<string>("name");
//                    if (!string.IsNullOrEmpty(name))
//                    {
//                        return productRepository.GetAll().Where(r => r.Name == name);
//                    }

//                    var makeFlag = context.GetArgument<bool?>("makeFlag");
//                    if (makeFlag.HasValue)
//                    {
//                        return productRepository.GetAll()
//                            .Where(r => r.MakeFlag == makeFlag.Value);
//                    }

//                    var finishedGoodsFlag = context.GetArgument<bool?>("finishedGoodsFlag");
//                    if (finishedGoodsFlag.HasValue)
//                    {
//                        return productRepository.GetAll()
//                            .Where(r => r.FinishedGoodsFlag == finishedGoodsFlag.Value);
//                    }

//                    //var checkoutDate = context.GetArgument<DateTime?>("checkoutDate");
//                    //if (checkoutDate.HasValue)
//                    //{
//                    //    return reservationRepository.GetQuery()
//                    //        .Where(r => r.CheckoutDate.Date >= checkoutDate.Value.Date);
//                    //}

//                    //var allowedSmoking = context.GetArgument<bool?>("roomAllowedSmoking");
//                    //if (allowedSmoking.HasValue)
//                    //{
//                    //    return reservationRepository.GetQuery()
//                    //        .Where(r => r.Room.AllowedSmoking == allowedSmoking.Value);
//                    //}

//                    //var roomStatus = context.GetArgument<RoomStatus?>("roomStatus");
//                    //if (roomStatus.HasValue)
//                    //{
//                    //    return reservationRepository.GetQuery().Where(r => r.Room.Status == roomStatus.Value);
//                    //}

//                    //return query.ToList();
//                    return query;
//                }
//            );
//        }
//    }
//}
