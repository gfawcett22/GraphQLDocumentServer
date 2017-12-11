using GraphQL.Types;
using GraphQLServer.Api.GraphQL.Types;
using GraphQLServer.Core.Data;

namespace GraphQLServer.Api.Api.GraphQL.Queries
{
    public class DocumentQuery : ObjectGraphType
    {
        public DocumentQuery() { }

        public DocumentQuery(IDocumentRepository docRepo, IDocumentTypeRepository docTypeRepo)
        {
            Name = "Query";

            Field<ListGraphType<DocumentType>>("documents",
                resolve: context => docRepo.GetDocuments());

            Field<DocumentType>("document",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return docRepo.GetDocument(id);
                });

            Field<ListGraphType<DocumentTypeType>>("documentTypes",
                resolve: context => docTypeRepo.GetDocumentTypes());

            Field<DocumentTypeType>("documentType",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return docTypeRepo.GetDocumentType(id);
                });
        }
    }
}
