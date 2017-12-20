using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.GraphQL.Types.Input
{
    public class KeywordTypeInputType : InputObjectGraphType
    {
        public KeywordTypeInputType()
        {
            Name = "KeywordTypeInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<BooleanGraphType>("invisible");
            Field<BooleanGraphType>("notForRetrieval");
            Field<NonNullGraphType<StringGraphType>>("dataType");
    }
    }
}
