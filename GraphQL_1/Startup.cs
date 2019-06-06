using GraphiQl;
using GraphQL;
using GraphQL.EntityFramework;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQL.Types.Relay;
using GraphQL.Utilities;
using GraphQL_1.Data;
using GraphQL_1.GraphQL;
using GraphQL_1.Models;
using GraphQL_1.Repository;
using GraphQL_1.SimonCropp;
using GraphQL_1.SimonCropp.Graphs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL_1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddNewtonsoftJson();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            // ################################################
            // ************** SimonCropp - start **************
            // ################################################
            GraphTypeTypeRegistry.Register<Product, ProductGraph>();
            GraphTypeTypeRegistry.Register<ProductReview, ProductReviewGraph>();
            GraphTypeTypeRegistry.Register<ProductCategory, ProductCategoryGraph>();
            GraphTypeTypeRegistry.Register<ProductSubcategory, ProductSubcategoryGraph>();
            GraphTypeTypeRegistry.Register<TransactionHistory, TransactionHistoryGraph>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("GraphQL_1Db")));

            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(Configuration.GetConnectionString("GraphQL_1Db"));
            using (var myDataContext = new AppDbContext(builder.Options))
            {
                EfGraphQLConventions.RegisterInContainer(
                    services,
                    myDataContext,
                    userContext => (AppDbContext)userContext
                );

                //var x = new ProductRepository(myDataContext);
                //var x1 = x.GetAll();
            }

            foreach (var type in GetGraphQlTypes())
            {
                services.AddSingleton(type);
            }

            //services.AddGraphQL(options => options.ExposeExceptions = true).AddWebSockets();
            services.AddSingleton<ContextFactory>();
            services.AddSingleton<IDocumentExecuter, EfDocumentExecuter>();
            services.AddScoped<IDependencyResolver>(
                provider => new FuncDependencyResolver(provider.GetRequiredService));
            services.AddScoped<ISchema, SimonCropp.Schema>();        // AddSingleton
            var mvc = services.AddMvc();
            mvc.SetCompatibilityVersion(CompatibilityVersion.Latest);

            // Connection Types - GraphQL enables paging via Connections
            //services.AddTransient(typeof(ConnectionType<>));
            //services.AddTransient(typeof(EdgeType<>));
            //services.AddTransient<PageInfoType>();
            EfGraphQLConventions.RegisterConnectionTypesInContainer(services);
            // ##############################################
            // ************** SimonCropp - end **************
            // ##############################################



            // #############################################
            // ************** GraphQL - start **************
            // #############################################

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });


            // STAVIO SAM U KOMENTAR POSTO GA KORISTIM U OKVIRU SimonCropp
            //services.AddDbContextPool<AppDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("GraphQL_1Db")));
            services.AddTransient<ProductRepository>();     // AddScoped
            services.AddTransient<ProductSubcategoryRepository>();
            //******< GraphQL Services >******


            // STAVIO SAM U KOMENTAR POSTO GA KORISTIM U OKVIRU SimonCropp
            //services.AddScoped<IDependencyResolver>(provider =>
            //    new FuncDependencyResolver(provider.GetRequiredService));

            services.AddScoped<AdventureWorksSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true; //set true only in dev mode. // options.ExposeExceptions = this.Environment.IsDevelopment();
            })
                .AddGraphTypes(ServiceLifetime.Scoped)  //.AddUserContextBuilder(httpContext => httpContext.User)
                .AddDataLoader();
            // ###########################################
            // ************** GraphQL - end **************
            // ###########################################
        }

        static IEnumerable<Type> GetGraphQlTypes()
        {
            return typeof(Startup).Assembly
                .GetTypes()
                .Where(x => !x.IsAbstract &&
                            (typeof(IObjectGraphType).IsAssignableFrom(x) ||
                             typeof(IInputObjectGraphType).IsAssignableFrom(x)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseGraphQL<ISchema>("/ql");     //AdventureWorksSchema   // ISchema
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); //to explorer API navigate https://*DOMAIN*/ui/playground
            app.UseGraphiQl("/graphiql", "/graphql");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
