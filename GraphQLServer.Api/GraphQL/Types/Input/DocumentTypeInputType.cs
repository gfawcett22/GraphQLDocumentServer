using GraphQL.Types;

namespace GraphQLServer.Api.GraphQL.Types.Input
{
    public class DocumentTypeInputType : InputObjectGraphType
    {
        public DocumentTypeInputType()
        {
            Name = "DocumentTypeInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<ListGraphType<IntGraphType>>("keywordTypeIds");
        }
    }
}
