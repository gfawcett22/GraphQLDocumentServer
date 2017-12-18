using GraphQL.Types;
using GraphQLServer.Core.Models;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class KeywordGraphType: ObjectGraphType<Keyword>
    {
        public KeywordGraphType()
        {
            Field(x => x.KeywordId).Name("id").Description("The ID of the Keyword");
            Field<KeywordTypeGraphType>("keywordType");
            Field(x => x.Value).Name("value").Description("The value for the Keyword");
        }
    }
}
