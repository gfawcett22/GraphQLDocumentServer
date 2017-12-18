using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GraphQLServer.Core.Data;
using GraphQL.Types;
using GraphQLServer.Api.GraphQL.Schemas;
using GraphQL;
using GraphQLServer.Core.Repositories;
using GraphQLServer.Core.Contexts;
using GraphQLServer.Api.Api.GraphQL.Queries;
using GraphQLServer.Data.Seed;
using Microsoft.Extensions.Logging;

namespace GraphQLServer.Api
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
            var dbHostName = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost";
            Console.WriteLine($"SQL Server Host: {dbHostName}");
            var dbPassword = Environment.GetEnvironmentVariable("SQLSERVER_SA_PASSWORD") ?? "Password123";
            Console.WriteLine($"SQL Server Host: {dbPassword}");
            var connString = $"Data Source={dbHostName};Initial Catalog=GraphQL;User ID=sa;Password={dbPassword};";
            services.AddDbContext<DocumentContext>(options => options.UseSqlServer(connString));
            //services.AddDbContext<DocumentContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GraphDatabaseConnection")));
            //services.AddDbContext<DocumentContext>(options => options.UseInMemoryDatabase("Test"));
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IKeywordRepository, KeywordRepository>();
            services.AddScoped<IKeywordTypeRepository, KeywordTypeRepository>();

            services.AddScoped<DocumentQuery>();

            // GraphQL Types
            services.AddTransient<GraphQL.Types.DocumentGraphType>();
            services.AddTransient<GraphQL.Types.DocumentTypeGraphType>();
            services.AddTransient<GraphQL.Types.KeywordGraphType>();
            services.AddTransient<GraphQL.Types.KeywordTypeGraphType>();

            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new DocumentSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<DocumentQuery>() });


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider sv)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc();

            using (var db = sv.GetService<DocumentContext>())
            {
                //db.Database.Migrate();
                DocumentContextSeeder.Seed(db);
            }
        }
    }
}
