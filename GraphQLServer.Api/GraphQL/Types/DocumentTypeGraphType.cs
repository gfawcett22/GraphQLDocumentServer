using GraphQL.Types;
using GraphQLServer.Core.Data;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class DocumentTypeGraphType : ObjectGraphType<GraphQLServer.Core.Models.DocumentType>
    {
        public DocumentTypeGraphType(IDocumentRepository docRepo, IKeywordTypeRepository keywordTypeRepo)
        {
            Field(x => x.DocumentTypeId).Name("Id").Description("The Id of the Document Type");
            Field(x => x.Name).Description("The Name of the Document Type");
            Field<ListGraphType<KeywordTypeGraphType>>("keywordTypes", 
                resolve: context => keywordTypeRepo.GetKeywordTypes());
            Field<ListGraphType<DocumentGraphType>>("documents", 
                resolve: context => docRepo.GetDocuments(context.Source.DocumentTypeId));
        }
    }
}
