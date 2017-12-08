using GraphQLServer.Api.GraphQL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

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
