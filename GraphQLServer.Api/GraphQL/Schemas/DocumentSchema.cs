using System;
using GraphQL.Types;
using GraphQLServer.Api.Api.GraphQL.Queries;

namespace GraphQLServer.Api.GraphQL.Schemas
{
    public class DocumentSchema : Schema
    {
        public DocumentSchema(Func<Type, GraphType> resolveType) : base(resolveType)
        {
            Query = (DocumentQuery)resolveType(typeof(DocumentQuery));
        }
    }
}
