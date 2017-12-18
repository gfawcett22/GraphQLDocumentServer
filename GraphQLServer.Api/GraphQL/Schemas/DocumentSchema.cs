using System;
using GraphQL.Types;
using GraphQLServer.Api.Api.GraphQL.Queries;
using GraphQLServer.Api.GraphQL.Mutations;

namespace GraphQLServer.Api.GraphQL.Schemas
{
    public class DocumentSchema : Schema
    {
        public DocumentSchema(Func<Type, GraphType> resolveType) : base(resolveType)
        {
            Query = (DocumentQuery)resolveType(typeof(DocumentQuery));
            Mutation = (DocumentMutation)resolveType(typeof(DocumentMutation));
        }
    }
}
