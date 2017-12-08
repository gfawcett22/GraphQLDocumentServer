using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphQLServer.Api.Contexts;
using Microsoft.EntityFrameworkCore;
using GraphQLServer.Api.GraphQL.Middleware;
using GraphQLServer.Api.Repositories;
using GraphQL.Types;
using GraphQLServer.Api.GraphQL.Schemas;
using GraphQLServer.Api.GraphQL.Queries;
using GraphQL;

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
            services.AddDbContext<DocumentContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GraphDatabaseConnection")));
            //services.AddDbContext<DocumentContext>(options => options.UseInMemoryDatabase("Test"));
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            //services.AddScoped<IDocumentExecuter, DocumentExecuter>();

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

            
            app.UseGraphQL();

            app.UseMvc();
        }
    }
}
