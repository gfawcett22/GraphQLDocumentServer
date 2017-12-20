using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.GraphQL.Types.Input
{
    public class KeywordInputType : InputObjectGraphType
    {
        public KeywordInputType()
        {
            Name = "KeywordInputType";
            Field<NonNullGraphType<IntGraphType>>("keywordType");
            Field<NonNullGraphType<StringGraphType>>("value");
        }
    }
}
