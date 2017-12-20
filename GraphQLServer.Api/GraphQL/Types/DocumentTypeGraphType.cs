using AutoMapper;
using GraphQL.Types;
using GraphQLServer.Api.Models.DocumentType;
using GraphQLServer.Api.Models.KeywordType;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Models;
using System.Collections.Generic;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class DocumentTypeGraphType : ObjectGraphType<DocumentTypeDto>
    {
        public DocumentTypeGraphType(IDocumentRepository docRepo, IKeywordTypeRepository keywordTypeRepo, IMapper mapper)
        {
            Field(x => x.DocumentTypeId).Name("Id").Description("The Id of the Document Type");
            Field(x => x.Name).Description("The Name of the Document Type");
            Field<ListGraphType<KeywordTypeGraphType>>("keywordTypes", 
                resolve: context => mapper.Map<IEnumerable<KeywordType>, IEnumerable<KeywordTypeDto>>(keywordTypeRepo.GetKeywordTypes(context.Source.DocumentTypeId)));
            Field<ListGraphType<DocumentGraphType>>("documents", 
                resolve: context => mapper.Map<IEnumerable<Document>, IEnumerable<DocumentTypeDto>>(docRepo.GetDocuments(context.Source.DocumentTypeId)));
        }
    }
}
