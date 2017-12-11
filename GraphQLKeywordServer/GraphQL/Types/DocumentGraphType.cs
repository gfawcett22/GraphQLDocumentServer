using GraphQL.Types;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Models;
using System.Linq;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class DocumentGraphType : ObjectGraphType<Document>
    {
        public DocumentGraphType(IKeywordRepository keywordRepo)
        {
            Field(x => x.DocumentId).Name("Id").Description("The ID of the Document");
            Field(x => x.AutoNameString).Description("The Auto Name string to be displayed in the UI");
            Field<DocumentTypeGraphType>("documentType");
            Field<ListGraphType<KeywordGraphType>>("keywords",
                resolve: context => keywordRepo.GetKeywords(context.Source.DocumentId).ToList()
            );
        }
    }
}
