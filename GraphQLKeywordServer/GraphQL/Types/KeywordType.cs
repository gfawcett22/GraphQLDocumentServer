using GraphQL.Types;
using GraphQLServer.Core.Models;

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
