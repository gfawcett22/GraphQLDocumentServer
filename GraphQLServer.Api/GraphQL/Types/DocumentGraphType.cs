using AutoMapper;
using GraphQL.Types;
using GraphQLServer.Api.Models.Document;
using GraphQLServer.Api.Models.DocumentType;
using GraphQLServer.Api.Models.Keyword;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Models;
using System.Collections.Generic;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class DocumentGraphType : ObjectGraphType<DocumentDto>
    {
        public DocumentGraphType(IDocumentTypeRepository docTypeRepo, IKeywordRepository keywordRepo, IMapper mapper)
        {
            Field(x => x.DocumentId).Name("Id").Description("The ID of the Document");
            Field(x => x.AutoNameString).Description("The Auto Name string to be displayed in the UI");
            Field<DocumentTypeGraphType>("documentType",
                resolve: context => mapper.Map<DocumentType, DocumentTypeDto>(docTypeRepo.GetDocumentTypeForDocument(context.Source.DocumentId)));
            Field<ListGraphType<KeywordGraphType>>("keywords",
                resolve: context => {
                    var test = mapper.Map<IEnumerable<Keyword>, IEnumerable<KeywordDto>>(keywordRepo.GetKeywords(context.Source.DocumentId));
                    return test;
                });
        }
    }
}
