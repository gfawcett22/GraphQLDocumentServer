using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class DocumentInputType : InputObjectGraphType
    {
        public DocumentInputType()
        {
            Name = "DocumentInput";
            Field<NonNullGraphType<StringGraphType>>("autoNameString");
            Field<NonNullGraphType<IntGraphType>>("documentTypeId");
            Field<ListGraphType<IntGraphType>>("keywordIds");
        }
    }
}
