using GraphQL;
using GraphQL.EntityFramework;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types.Relay;
using GraphQL.Utilities;
using GraphQL_1.Data;
using GraphQL_1.GraphQL;
using GraphQL_1.GraphQL.Graphs;
using GraphQL_1.GraphQL.Types;
using GraphQL_1.Models;
using GraphQL_1.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//using GraphiQl;
using GraphQL.EntityFramework;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;
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

            // *****************SimonCropp******************
            // ********** GraphQL.EntityFramework **********
            // *********************************************
            GraphTypeTypeRegistry.Register<Product, ProductGraph>();
            //services.AddScoped(provider => DbContextBuilder.BuildDbContext());

            var appDbContext = new AppDbContext();
            //EfGraphQLConventions.RegisterInContainer(
            //    services,
            //    appDbContext,       //DbContextBuilder.BuildDbContext(),
            //    userContext => (AppDbContext)userContext
            //);
            foreach (var type in GetGraphQlTypes())
            {
                services.AddSingleton(type);
            }
            services.AddTransient(typeof(ConnectionType<>));
            services.AddTransient(typeof(EdgeType<>));
            services.AddTransient<PageInfoType>();

            // ******************************
            // ********** OBAVEZNO **********
            // ******************************
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            //var tmp1 = services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("GraphQL_1Db")));
            //services.AddScoped<ProductRepository>();
            services.AddTransient<ProductRepository>();
            services.AddTransient<ProductSubcategoryRepository>();
            //******< GraphQL Services >******
            services.AddScoped<IDependencyResolver>(provider =>
                new FuncDependencyResolver(provider.GetRequiredService));
            //  //services.AddScoped<ProductType>();
            //  //services.AddScoped<ProductQuery>();
            //services.AddScoped<AdventureWorksSchema>();
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                // options.ExposeExceptions = this.Environment.IsDevelopment();
                options.ExposeExceptions = true; //set true only in dev mode. //
            })
                .AddGraphTypes(ServiceLifetime.Scoped)
                //.AddUserContextBuilder(httpContext => httpContext.User)
                .AddDataLoader();
            //******</ GraphQL Services >****** 

            services.AddSingleton<IDocumentExecuter, EfDocumentExecuter>();
            services.AddSingleton<ISchema, AdventureWorksSchema>();
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

            // app.UseGraphQL<WebApp5Schema>("/graphql");
            app.UseGraphQL<ISchema>();     //AdventureWorksSchema
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); //to explorer API navigate https://*DOMAIN*/ui/playground

            // ********** GraphQL.EntityFramework **********
            app.UseWebSockets();
            //app.UseGraphQLWebSockets<ISchema>();

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
