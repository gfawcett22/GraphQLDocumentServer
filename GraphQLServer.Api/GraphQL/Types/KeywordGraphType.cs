using GraphQL.Types;
using GraphQLServer.Api.Models.Keyword;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class KeywordGraphType: ObjectGraphType<KeywordDto>
    {
        public KeywordGraphType()
        {
            Field(x => x.KeywordId).Name("id").Description("The ID of the Keyword");
            Field(x => x.Value).Name("value").Description("The value for the Keyword");
            Field<KeywordTypeGraphType>("keywordType");
        }
    }
}
