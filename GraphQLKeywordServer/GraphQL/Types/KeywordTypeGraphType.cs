using GraphQL.Types;
using GraphQLServer.Core.Data;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class KeywordTypeGraphType: ObjectGraphType<Core.Models.KeywordType>
    {
        public KeywordTypeGraphType() { }
        public KeywordTypeGraphType(IDocumentTypeRepository docTypeRepo)
        {
            Field(x => x.KeywordTypeId).Description("The Id of the Keyword Type");
            Field(x => x.Name).Description("The Name of the Keyword Type");
            Field(x => x.Invisible).Description("If the Keyword Type is invisible");
            Field(x => x.NotForRetrieval).Description("If the Keyword Type is to be used in Retrieval");
            Field<ListGraphType<DocumentGraphType>>("documentTypes", 
                resolve: context => docTypeRepo.GetDocumentTypes());
        }
    }
}
