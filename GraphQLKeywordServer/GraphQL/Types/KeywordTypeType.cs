using GraphQL.Types;
using GraphQLServer.Api.Models;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class KeywordTypeType: ObjectGraphType<Models.KeywordType>
    {
        public KeywordTypeType()
        {
            Field(x => x.KeywordTypeId).Description("The Id of the Keyword Type");
            Field(x => x.Name).Description("The Name of the Keyword Type");
            Field(x => x.Invisible).Description("If the Keyword Type is invisible");
            Field(x => x.NotForRetrieval).Description("If the Keyword Type is to be used in Retrieval");
        }
    }
}
