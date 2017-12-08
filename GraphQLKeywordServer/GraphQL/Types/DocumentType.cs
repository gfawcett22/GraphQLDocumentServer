using GraphQL.Types;
using GraphQLServer.Api.Models;
using GraphQLServer.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class DocumentType : ObjectGraphType<Document>
    {
        public DocumentType(IDocumentRepository repo)
        {
            Field(x => x.DocumentId).Name("Id").Description("The ID of the Document");
            Field(x => x.AutoNameString).Description("The Auto Name string to be displayed in the UI");
            Field<DocumentTypeType>("documentType");
            Field<ListGraphType<KeywordType>>("keywords", null, null,
                resolve: context => context.Source.DocumentKeywords.Select(dk => dk.Keyword).ToList()
            );
        }
    }
}
