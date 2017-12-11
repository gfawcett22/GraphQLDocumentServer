using GraphQL.Types;
using GraphQLServer.Core.Data;
using System.Linq;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class DocumentTypeType : ObjectGraphType<GraphQLServer.Core.Models.DocumentType>
    {
        public DocumentTypeType(IDocumentRepository docRepo)
        {
            Field(x => x.DocumentTypeId).Name("Id").Description("The Id of the Document Type");
            Field(x => x.Name).Description("The Name of the Document Type");
            Field<ListGraphType<KeywordTypeType>>("keywordTypes", 
                resolve: context => context.Source.DocumentTypeKeywordTypes.Select(dtkt => dtkt.KeywordType).ToList());
            Field<ListGraphType<DocumentType>>("documents", 
                resolve: context => docRepo.GetDocuments().AsQueryable().Where(d => d.DocumentType.DocumentTypeId == context.Source.DocumentTypeId));
        }
    }
}
