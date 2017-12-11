using GraphQL.Types;
using GraphQLServer.Api.GraphQL.Types;
using GraphQLServer.Core.Data;

namespace GraphQLServer.Api.Api.GraphQL.Queries
{
    public class DocumentQuery : ObjectGraphType
    {
        public DocumentQuery() { }

        public DocumentQuery(IDocumentRepository docRepo, IDocumentTypeRepository docTypeRepo, IKeywordRepository keywordRepo, IKeywordTypeRepository keywordTypeRepo)
        {
            Name = "Query";

            Field<ListGraphType<DocumentGraphType>>("documents",
                resolve: context => docRepo.GetDocuments());

            Field<DocumentGraphType>("document",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return docRepo.GetDocument(id);
                });

            Field<ListGraphType<DocumentTypeGraphType>>("documentTypes",
                resolve: context => docTypeRepo.GetDocumentTypes());

            Field<DocumentTypeGraphType>("documentType",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return docTypeRepo.GetDocumentType(id);
                });

            Field<KeywordGraphType>("keywords",
                resolve: context => keywordRepo.GetKeywords());

            Field<KeywordGraphType>("keyword",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return keywordRepo.GetKeyword(id);
                });

            Field<KeywordGraphType>("keywordTypess",
                resolve: context => keywordTypeRepo.GetKeywordTypes());

            Field<KeywordGraphType>("keywordType",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return keywordTypeRepo.GetKeywordType(id);
                });
        }
    }
}
