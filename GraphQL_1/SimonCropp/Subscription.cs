using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.EntityFramework;
using GraphQL.Execution;
using GraphQL.Language.AST;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using GraphQL_1.Data;
using GraphQL_1.Models;
using GraphQL_1.SimonCropp.Graphs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ExecutionContext = GraphQL.Execution.ExecutionContext;

namespace GraphQL_1.SimonCropp
{
    public class Subscription : ObjectGraphType<object>
    {
        public Subscription(ContextFactory contextFactory, ILogger<Subscription> logger)
        {
            AddField(new EventStreamFieldType
            {
                Name = "productChanged",
                Type = typeof(ProductGraph),
                Resolver = new FuncFieldResolver<Product>(context => (Product)context.Source),
                Subscriber = new EventStreamResolver<Product>(context => Subscribe(context, contextFactory, logger))
            });
        }

        IObservable<Product> Subscribe(ResolveEventStreamContext context, ContextFactory contextFactory, ILogger logger)
        {
            long lastId = 0;
            var inner = Observable.Using(
                token => Task.FromResult(contextFactory.BuildContext()),
                async (ctx, token) =>
                {
                    try
                    {
                        var products = await GetProducts(context, ctx, lastId, token: token);

                        if (products.Any())
                        {
                            lastId = products.Max(transaction => transaction.ProductId);
                        }

                        return products.ToObservable();
                    }
                    catch (OperationCanceledException)
                    {
                        logger.LogInformation("Products subscription has been cancelled.");
                        return Observable.Empty<Product>();
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, "Unable to get products.");
                        return Observable.Empty<Product>();
                    }
                });

            return Observable.Interval(TimeSpan.FromSeconds(1)).SelectMany(_ => inner);
        }

        async Task<List<Product>> GetProducts(
            ResolveEventStreamContext context,
            AppDbContext ctx,
            long lastId,
            int take = 1,
            CancellationToken token = default)
        {
            var returnType = ctx.Product;

            var document = new GraphQLDocumentBuilder().Build(SupposePersistedQuery());

            var fieldContext = ResolveFieldContext(ctx, token, document, context.Schema);

            var withArguments = returnType.ApplyGraphQlArguments(fieldContext);

            var greaterThanLastIdAndPaged = withArguments
                .Where(transaction => transaction.ProductId > lastId)
                .Take(take);

            return await greaterThanLastIdAndPaged.ToListAsync(token);
        }

        static string SupposePersistedQuery()
        {
            return @"{
            products
            {
                productId
            }
        }";
        }

        ResolveFieldContext ResolveFieldContext(
            AppDbContext ctx,
            CancellationToken token,
            Document document,
            ISchema schema)
        {
            var operation = document.Operations.FirstOrDefault();
            var variableValues = ExecutionHelper.GetVariableValues(document, schema, operation?.Variables, null);
            var executionContext = new ExecutionContext
            {
                Document = document,
                Schema = schema,
                UserContext = ctx,
                Variables = variableValues,
                Fragments = document.Fragments,
                CancellationToken = token,
                Listeners = new IDocumentExecutionListener[0],
                Operation = operation,
                ThrowOnUnhandledException = true // DEBUG
            };

            var operationRootType = ExecutionHelper.GetOperationRootType(
                executionContext.Document,
                executionContext.Schema,
                executionContext.Operation);

            var node = ExecutionStrategy.BuildExecutionRootNode(executionContext, operationRootType);

            return GetContext(executionContext, node.SubFields["products"]);
        }

        ResolveFieldContext GetContext(ExecutionContext context, ExecutionNode node)
        {
            var argumentValues = ExecutionHelper.GetArgumentValues(context.Schema,
                node.FieldDefinition.Arguments, node.Field.Arguments, context.Variables);
            var dictionary = ExecutionHelper.SubFieldsFor(context, node.FieldDefinition.ResolvedType, node.Field);
            return new ResolveFieldContext
            {
                FieldName = node.Field.Name,
                FieldAst = node.Field,
                FieldDefinition = node.FieldDefinition,
                ReturnType = node.FieldDefinition.ResolvedType,
                ParentType = node.GetParentType(context.Schema),
                Arguments = argumentValues,
                Source = node.Source,
                Schema = context.Schema,
                Document = context.Document,
                Fragments = context.Fragments,
                RootValue = context.RootValue,
                UserContext = context.UserContext,
                Operation = context.Operation,
                Variables = context.Variables,
                CancellationToken = context.CancellationToken,
                Metrics = context.Metrics,
                Errors = context.Errors,
                Path = node.Path,
                SubFields = dictionary
            };
        }
    }
}
