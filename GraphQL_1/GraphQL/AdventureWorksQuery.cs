using GraphQL;
using GraphQL.Types;
using GraphQL_1.GraphQL.Types;
using GraphQL_1.Models;
using GraphQL_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GraphQL_1.GraphQL
{
    public class AdventureWorksQuery : ObjectGraphType
    {
        public AdventureWorksQuery(ProductRepository productRepository, ProductSubcategoryRepository productSubcategoryRepository)
        {
            /*-- Simple test query --
                query Products {
                    products(productId: 1) {
                        productId: productId
                        name,
                        makeFlag,
                        finishedGoodsFlag,
                        productNumber,
                        color
                        transactionHistory{
                            transactionId,
                            transactionDate,
                            transactionType,
                            quantity,
                            actualCost,
                            modifiedDate
                        }
                        productSubcategory{
                            productSubcategoryId
                            name
                            rowguid
                            modifiedDate
                        }
                    }
                }
            */

            //Field<ListGraphType<ProductType>>(
            //    "products",
            //    resolve: context => productRepository.GetAll());

            /*Version: 2 filtering*/
            Field<ListGraphType<ProductType>>(
                "products",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType> { Name = "productId" },
                    new QueryArgument<ListGraphType<IdGraphType>> { Name = "productIds" },
                    new QueryArgument<StringGraphType> { Name = "name" },
                    new QueryArgument<BooleanGraphType> { Name = "makeFlag" },
                    new QueryArgument<BooleanGraphType> { Name = "finishedGoodsFlag" },
                    new QueryArgument<StringGraphType> { Name = "productNumber" },
                    new QueryArgument<StringGraphType> { Name = "color" },
                    new QueryArgument<DecimalGraphType> { Name = "standardCost" },
                    new QueryArgument<DecimalGraphType> { Name = "listPrice" },
                    new QueryArgument<StringGraphType> { Name = "size" },
                    new QueryArgument<StringGraphType> { Name = "sizeUnitMeasureCode" },
                    new QueryArgument<StringGraphType> { Name = "weightUnitMeasureCode" },
                    new QueryArgument<DateTimeGraphType> { Name = "sellStartDate" },
                    new QueryArgument<DateTimeGraphType> { Name = "sellEndDate" },
                    new QueryArgument<StringGraphType> { Name = "order" }
                }),
                resolve: context =>
                {
                    //var user = (ClaimsPrincipal)context.UserContext;
                    //var isUserAuthenticated = ((ClaimsIdentity)user.Identity).IsAuthenticated;

                    var productId = context.GetArgument<int?>("productId");
                    var order = context.GetArgument<string>("order");

                    if (productId.HasValue && productId.Value != -411)
                    {
                        if (productId.Value <= 0 || productId.Value >= 10000)
                        {
                            context.Errors.Add(new ExecutionError("productId must be number between 1 and 9999!"));
                            return new List<Product>();
                        }
                        //List<int> listProductId = new List<int>();
                        //listProductId.Add(productId.Value);
                        //return productRepository.GetProductsAsync(listProductId);
                        return productRepository.GetAll(order, productId.Value);
                    }

                    var productIds = context.GetArgument<List<int?>>("productIds");
                    if (productIds != null /*|| productIds.Any()*/)
                    {
                        List<int> listProductIds = new List<int>();
                        listProductIds = productIds.Where(u => u != null)
                            .Select(u => u.Value)
                            .ToList();
                        return productRepository.GetProductsAsync(listProductIds);
                    }
                    //if (productIds == null || !productIds.Any())
                    //{
                    //    List<int> intList = new List<int>();
                    //    var tmp5 = productRepository.GetProductsAsync(new List<int>());
                    //    return tmp5;
                    //}

                    var name = context.GetArgument<string>("name");
                    if (!string.IsNullOrEmpty(name))
                    {
                        return productRepository.GetAll().Where(r => r.Name == name);
                    }

                    var makeFlag = context.GetArgument<bool?>("makeFlag");
                    if (makeFlag.HasValue)
                    {
                        return productRepository.GetAll()
                            .Where(r => r.MakeFlag == makeFlag.Value);
                    }

                    var finishedGoodsFlag = context.GetArgument<bool?>("finishedGoodsFlag");
                    if (finishedGoodsFlag.HasValue)
                    {
                        return productRepository.GetAll()
                            .Where(r => r.FinishedGoodsFlag == finishedGoodsFlag.Value);
                    }

                    //var checkoutDate = context.GetArgument<DateTime?>("checkoutDate");
                    //if (checkoutDate.HasValue)
                    //{
                    //    return reservationRepository.GetQuery()
                    //        .Where(r => r.CheckoutDate.Date >= checkoutDate.Value.Date);
                    //}

                    //var allowedSmoking = context.GetArgument<bool?>("roomAllowedSmoking");
                    //if (allowedSmoking.HasValue)
                    //{
                    //    return reservationRepository.GetQuery()
                    //        .Where(r => r.Room.AllowedSmoking == allowedSmoking.Value);
                    //}

                    //var roomStatus = context.GetArgument<RoomStatus?>("roomStatus");
                    //if (roomStatus.HasValue)
                    //{
                    //    return reservationRepository.GetQuery().Where(r => r.Room.Status == roomStatus.Value);
                    //}

                    var query = productRepository.GetAll();
                    return query;
                }
            );

            /*-- Simple test query --
            query ProductSubcategory{
                productSubcategories{
                    productSubcategoryId
                    name
                    rowguid
                    modifiedDate
                    product{
                        productId
                        name
                        weight
                    }
                    productCategory{
                        productCategoryId
                        name
                    }
                }
            }*/

            Field<ListGraphType<ProductSubcategoryType>>(
                "productSubcategories",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType> { Name = "productSubcategoryId" },
                    new QueryArgument<StringGraphType> { Name = "name" },
                    new QueryArgument<IdGraphType> { Name = "Rowguid" },
                    new QueryArgument<DateTimeGraphType> { Name = "ModifiedDate" }
                }),
                resolve: context =>
                {
                    //var query = productSubcategoryRepository.GetAllAsync();
                    var query = productSubcategoryRepository.GetAll();
                    return query;
                }
            );
        }
    }
}
