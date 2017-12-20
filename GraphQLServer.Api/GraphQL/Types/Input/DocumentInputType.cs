using GraphQL.Types;

namespace GraphQLServer.Api.GraphQL.Types.Input
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
