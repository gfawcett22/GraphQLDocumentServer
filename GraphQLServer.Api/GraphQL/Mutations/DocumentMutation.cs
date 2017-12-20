using AutoMapper;
using GraphQL.Types;
using GraphQLServer.Api.GraphQL.Types;
using GraphQLServer.Api.GraphQL.Types.Input;
using GraphQLServer.Api.Models.Document;
using GraphQLServer.Api.Models.DocumentType;
using GraphQLServer.Api.Models.Keyword;
using GraphQLServer.Api.Models.KeywordType;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Models;
using System.Linq;

namespace GraphQLServer.Api.GraphQL.Mutations
{
    public class DocumentMutation : ObjectGraphType<object>
    {
        public DocumentMutation(IDocumentRepository docRepo, IDocumentTypeRepository docTypeRepo, IKeywordRepository keywordRepo, IKeywordTypeRepository keywordTypeRepo, IMapper mapper)
        {
            Field<DocumentGraphType>("createDocument",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DocumentInputType>> { Name = "document" }
                ),
                resolve: context =>
                {
                    var document = context.GetArgument<DocumentToCreateDto>("document");
                    var mappedDoc = mapper.Map<Document>(document);
                    mappedDoc.DocumentType = docTypeRepo.GetDocumentType(document.DocumentTypeId);
                    var docKeywords = document.KeywordIds.Select(k => new DocumentKeyword { Document = mappedDoc, KeywordId = k }).ToList();
                    mappedDoc.DocumentKeywords = docKeywords;
                    docRepo.AddDocument(mappedDoc);
                    if (!docRepo.Save())
                    {
                        throw new System.Exception("Error creating new document");
                    }
                    var documentToReturn = mapper.Map<DocumentDto>(mappedDoc);
                    return documentToReturn;
                });

            Field<DocumentTypeGraphType>("createDocumentType",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DocumentTypeInputType>> { Name = "documentType" }
                ),
                resolve: context =>
                {
                    var documentType = context.GetArgument<DocumentTypeToCreateDto>("documentType");
                    var mappedDocType = mapper.Map<DocumentType>(documentType);
                    mappedDocType.DocumentTypeKeywordTypes = documentType.KeywordTypeIds.Select(kt => new DocumentTypeKeywordType { DocumentType = mappedDocType, KeywordTypeId = kt }).ToList();
                    docTypeRepo.AddDocumentType(mappedDocType);
                    if (!docTypeRepo.Save())
                    {
                        throw new System.Exception("Error creating new Document Type");
                    }
                    return mapper.Map<DocumentTypeDto>(mappedDocType);
                });

            Field<KeywordTypeGraphType>("createKeywordType",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<KeywordTypeInputType>> { Name = "keywordType" }
                    ),
                resolve: context =>
                {
                    var keywordType = context.GetArgument<KeywordTypeToCreateDto>("keywordType");
                    var mappedKeywordType = mapper.Map<KeywordType>(keywordType);
                    keywordTypeRepo.AddKeywordType(mappedKeywordType);
                    if (!keywordTypeRepo.Save())
                    {
                        throw new System.Exception("Error creating new Keyword Type");
                    }
                    return mapper.Map<KeywordTypeDto>(mappedKeywordType);
                });

            Field<KeywordGraphType>("createKeyword",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<KeywordInputType>> { Name = "keyword" }
                    ),
                resolve: context =>
                {
                    var keyword = context.GetArgument<KeywordToCreateDto>("keyword");
                    var mappedKeyword = mapper.Map<Keyword>(keyword);
                    keywordRepo.AddKeyword(mappedKeyword);
                    if (!keywordRepo.Save())
                    {
                        throw new System.Exception("Error creating keyword");
                    }
                    return mapper.Map<KeywordDto>(mappedKeyword);
                });
        }
    }
}
