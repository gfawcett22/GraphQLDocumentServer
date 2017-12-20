using AutoMapper;
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
using GraphQLServer.Api.GraphQL.Mutations;

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
            services.AddAutoMapper(typeof(Startup));
            var dbHostName = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost";
            Console.WriteLine($"SQL Server Host: {dbHostName}");
            var dbPassword = Environment.GetEnvironmentVariable("SQLSERVER_SA_PASSWORD") ?? "Password123";
            Console.WriteLine($"SQL Server Host: {dbPassword}");
            var connString = $"Data Source={dbHostName};Initial Catalog=GraphQL;User ID=sa;Password={dbPassword};";
            services.AddDbContext<DocumentContext>(options => options.UseSqlServer(connString));

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IKeywordRepository, KeywordRepository>();
            services.AddScoped<IKeywordTypeRepository, KeywordTypeRepository>();

            services.AddScoped<DocumentQuery>();
            services.AddScoped<DocumentMutation>();

            // GraphQL Types
            services.AddTransient<GraphQL.Types.DocumentGraphType>();
            services.AddTransient<GraphQL.Types.DocumentTypeGraphType>();
            services.AddTransient<GraphQL.Types.KeywordGraphType>();
            services.AddTransient<GraphQL.Types.KeywordTypeGraphType>();
            // Input Types
            services.AddTransient<GraphQL.Types.Create.DocumentCreateInputType>();
            services.AddTransient<GraphQL.Types.Create.DocumentTypeCreateInputType>();
            services.AddTransient<GraphQL.Types.Create.KeywordTypeCreateInputType>();
            services.AddTransient<GraphQL.Types.Create.KeywordCreateInputType>();
            // Update Types
            services.AddTransient<GraphQL.Types.Update.DocumentUpdateInputType>();
            services.AddTransient<GraphQL.Types.Update.DocumentTypeUpdateInputType>();
            services.AddTransient<GraphQL.Types.Update.KeywordTypeUpdateInputType>();
            services.AddTransient<GraphQL.Types.Update.KeywordUpdateInputType>();

            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new DocumentSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<DocumentQuery>(), Mutation = sp.GetService<DocumentMutation>() });

            
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
