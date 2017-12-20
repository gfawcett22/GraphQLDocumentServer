using AutoMapper;
using GraphQL.Types;
using GraphQLServer.Api.GraphQL.Types;
using GraphQLServer.Api.Models.Document;
using GraphQLServer.Api.Models.DocumentType;
using GraphQLServer.Api.Models.Keyword;
using GraphQLServer.Api.Models.KeywordType;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Models;
using System.Collections.Generic;

namespace GraphQLServer.Api.Api.GraphQL.Queries
{
    public class DocumentQuery : ObjectGraphType
    {
        public DocumentQuery() { }

        public DocumentQuery(IDocumentRepository docRepo, IDocumentTypeRepository docTypeRepo, IKeywordRepository keywordRepo, IKeywordTypeRepository keywordTypeRepo, IMapper mapper)
        {
            Name = "Query";

            Field<ListGraphType<DocumentGraphType>>("documents",
                resolve: context => mapper.Map<IEnumerable<Document>, IEnumerable<DocumentDto>>(docRepo.GetDocuments()));

            Field<DocumentGraphType>("document",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var documentFromRepo = docRepo.GetDocument(id);
                    return mapper.Map<DocumentDto>(documentFromRepo);
                });

            Field<ListGraphType<DocumentTypeGraphType>>("documentTypes",
                resolve: context => mapper.Map<IEnumerable<DocumentType>, IEnumerable<DocumentTypeDto>>(docTypeRepo.GetDocumentTypes()));

            Field<DocumentTypeGraphType>("documentType",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var documentTypeFromRepo = docTypeRepo.GetDocumentType(id);
                    return mapper.Map<DocumentTypeDto>(documentTypeFromRepo);
                });

            Field<KeywordGraphType>("keywords",
                resolve: context => mapper.Map<IEnumerable<Keyword>, IEnumerable<KeywordDto>>(keywordRepo.GetKeywords()));

            Field<KeywordGraphType>("keyword",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var keywordFromRepo = keywordRepo.GetKeyword(id);
                    return mapper.Map<KeywordDto>(keywordFromRepo);
                });

            Field<KeywordGraphType>("keywordTypes",
                resolve: context => mapper.Map<IEnumerable<KeywordType>, IEnumerable<KeywordTypeDto>>(keywordTypeRepo.GetKeywordTypes()));

            Field<KeywordGraphType>("keywordType",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var keywordTypeFromRepo = keywordTypeRepo.GetKeywordType(id);
                    return mapper.Map<KeywordTypeDto>(keywordTypeFromRepo);
                });
        }
    }
}
