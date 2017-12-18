using AutoMapper;
using GraphQL.Types;
using GraphQLServer.Api.GraphQL.Types;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Models;

namespace GraphQLServer.Api.GraphQL.Mutations
{
    public class DocumentMutation : ObjectGraphType<object>
    {
        public DocumentMutation(IDocumentRepository docRepo, IMapper mapper)
        {
            Field<DocumentGraphType>("createDocument",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DocumentInputType>> { Name = "document" }
                ),
                resolve: context =>
                {
                    var document = context.GetArgument<DocumentInputType>("document");
                    var mappedDoc = mapper.Map<Document>(document);
                    docRepo.AddDocument(mappedDoc);
                    return docRepo.Save();
                });
        }
    }
}
