using AutoMapper;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using GraphQLServer.Api.Api.GraphQL.Queries;
using GraphQLServer.Api.GraphQL.Queries;
using GraphQLServer.Core.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.GraphQL.Middleware
{
    public static class GraphQlMiddlewareExtensions
    {
        public static IApplicationBuilder UseGraphQL(this IApplicationBuilder builder) => builder.UseMiddleware<GraphQLMiddleware>();
    }

    public class GraphQLMiddleware
    {
        private readonly RequestDelegate _next;

        public GraphQLMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IDocumentRepository docRepo, IDocumentTypeRepository docTypeRepo, IKeywordRepository keywordRepo, IKeywordTypeRepository keywordTypeRepo, IMapper mapper)
        {
            var sent = false;
            if (httpContext.Request.Path.StartsWithSegments("/graphql"))
            {
                using (var sr = new StreamReader(httpContext.Request.Body))
                {
                    var query = await sr.ReadToEndAsync();
                    if (!String.IsNullOrWhiteSpace(query))
                    {
                        var schema = new Schema { Query = new DocumentQuery(docRepo, docTypeRepo, keywordRepo, keywordTypeRepo, mapper) };
                        var result = await new DocumentExecuter()
                            .ExecuteAsync(opts =>
                            {
                                opts.Schema = schema;
                                opts.Query = query;
                            }).ConfigureAwait(false);

                        CheckForErrors(result);

                        await WriteResult(httpContext, result);

                        sent = true;
                    }
                }                
            }
            if (!sent)
            {
                await _next(httpContext);
            }
        }

        private async Task WriteResult(HttpContext httpContext, ExecutionResult result)
        {
            var json = new DocumentWriter(indent: true).Write(result);

            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);
        }

        private void CheckForErrors(ExecutionResult result)
        {
            if (result.Errors?.Count > 0)
            {
                var errors = new List<Exception>();
                foreach (var error in result.Errors)
                {
                    var ex = new Exception(error.Message);
                    if (error.InnerException != null)
                    {
                        ex = new Exception(error.Message, error.InnerException);
                    }
                    errors.Add(ex);
                }
                throw new AggregateException(errors);
            }
        }
    }
}
