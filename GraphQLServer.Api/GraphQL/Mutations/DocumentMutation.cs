using AutoMapper;
using GraphQL.Types;
using GraphQLServer.Api.GraphQL.Types;
using GraphQLServer.Api.GraphQL.Types.Create;
using GraphQLServer.Api.Models.Document;
using GraphQLServer.Api.Models.DocumentType;
using GraphQLServer.Api.Models.KeywordType;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLServer.Api.GraphQL.Mutations
{
    public class DocumentMutation : ObjectGraphType<object>
    {
        public DocumentMutation(IDocumentRepository docRepo, IDocumentTypeRepository docTypeRepo, IKeywordRepository keywordRepo, IKeywordTypeRepository keywordTypeRepo, IMapper mapper)
        {
            Field<DocumentGraphType>("createDocument",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DocumentCreateInputType>> { Name = "document" }
                ),
                resolve: (ResolveFieldContext<object> context) =>
                {
                    var document = context.GetArgument<DocumentToCreateDto>("document");
                    var mappedDoc = mapper.Map<Document>(document);
                    mappedDoc.DocumentType = docTypeRepo.GetDocumentType(document.DocumentTypeId);
                    var keywordsToCreate = mapper.Map<IEnumerable<Keyword>>(document.Keywords);
                    keywordRepo.AddKeywords(keywordsToCreate);
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
                    new QueryArgument<NonNullGraphType<DocumentTypeCreateInputType>> { Name = "documentType" }
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
                    new QueryArgument<NonNullGraphType<KeywordTypeCreateInputType>> { Name = "keywordType" }
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

            //Field<KeywordGraphType>("createKeyword",
            //    arguments: new QueryArguments(
            //        new QueryArgument<NonNullGraphType<KeywordCreateInputType>> { Name = "keyword" }
            //        ),
            //    resolve: context =>
            //    {
            //        var keyword = context.GetArgument<KeywordToCreateDto>("keyword");
            //        var mappedKeyword = mapper.Map<Keyword>(keyword);
            //        keywordRepo.AddKeyword(mappedKeyword);
            //        if (!keywordRepo.Save())
            //        {
            //            throw new System.Exception("Error creating keyword");
            //        }
            //        return mapper.Map<KeywordDto>(mappedKeyword);
            //    });

            Field<DocumentGraphType>("updateDocument",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<Types.Update.DocumentUpdateInputType>> { Name = "document" }
                ),
                resolve: (ResolveFieldContext<object> context) =>
                {
                    var document = context.GetArgument<DocumentToUpdateDto>("document");
                    var documentFromRepo = docRepo.GetDocument(document.DocumentTypeId);
                    mapper.Map(document, documentFromRepo);
                    docRepo.UpdateDocument(documentFromRepo);
                    if (!docRepo.Save())
                    {
                        throw new System.Exception("Error creating new document");
                    }
                    var documentToReturn = mapper.Map<DocumentDto>(documentFromRepo);
                    return documentToReturn;
                });
        }
    }
}
