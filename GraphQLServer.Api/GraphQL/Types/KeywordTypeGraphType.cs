using AutoMapper;
using GraphQL.Types;
using GraphQLServer.Api.Models.DocumentType;
using GraphQLServer.Api.Models.KeywordType;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Models;
using System.Collections.Generic;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class KeywordTypeGraphType: ObjectGraphType<KeywordTypeDto>
    {
        public KeywordTypeGraphType() { }
        public KeywordTypeGraphType(IDocumentTypeRepository docTypeRepo, IMapper mapper)
        {
            Field(x => x.KeywordTypeId).Description("The Id of the Keyword Type");
            Field(x => x.Name).Description("The Name of the Keyword Type");
            Field(x => x.Invisible).Description("If the Keyword Type is invisible");
            Field(x => x.NotForRetrieval).Description("If the Keyword Type is to be used in Retrieval");
            Field<ListGraphType<DocumentGraphType>>("documentTypes", 
                resolve: context => mapper.Map<IEnumerable<DocumentType>, IEnumerable<DocumentTypeDto>>(docTypeRepo.GetDocumentTypes()));
        }
    }
}
