using GraphQL.Types;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Models;
using System.Linq;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class DocumentType : ObjectGraphType<Document>
    {
        public DocumentType(IDocumentRepository repo)
        {
            Field(x => x.DocumentId).Name("Id").Description("The ID of the Document");
            Field(x => x.AutoNameString).Description("The Auto Name string to be displayed in the UI");
            Field<DocumentTypeType>("documentType");
            Field<ListGraphType<KeywordType>>("keywords",
                resolve: context => context.Source.DocumentKeywords.Select(dk => dk.Keyword).ToList()
            );
        }
    }
}
