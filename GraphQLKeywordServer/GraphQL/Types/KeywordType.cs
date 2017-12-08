using GraphQL.Types;
using GraphQLServer.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class KeywordType: ObjectGraphType<Keyword>
    {
        public KeywordType()
        {
            Field(x => x.KeywordId).Name("id").Description("The ID of the Keyword");
            Field<KeywordTypeType>("keywordType");
            Field(x => x.Value).Name("value").Description("The value for the Keyword");
        }
    }
}
