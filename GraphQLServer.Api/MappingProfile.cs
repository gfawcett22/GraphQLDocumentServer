using AutoMapper;
using GraphQLServer.Api.GraphQL.Types;
using GraphQLServer.Api.GraphQL.Types.Create;
using GraphQLServer.Api.Models.Document;
using GraphQLServer.Api.Models.DocumentType;
using GraphQLServer.Api.Models.Keyword;
using GraphQLServer.Api.Models.KeywordType;
using GraphQLServer.Core.Models;

namespace GraphQLServer.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // DocumentDto
            CreateMap<Document, DocumentDto>();
            CreateMap<DocumentToCreateDto, Document>();
            CreateMap<DocumentToUpdateDto, Document>();
            // DocumentTypeDto
            CreateMap<DocumentType, DocumentTypeDto>();
            CreateMap<DocumentTypeToCreateDto, DocumentType>();
            CreateMap<DocumentTypeToUpdateDto, DocumentType>();
            // KeywordDto
            CreateMap<Keyword, KeywordDto>();
            CreateMap<KeywordToCreateDto, Keyword>();
            CreateMap<KeywordToUpdateDto, Keyword>();
            // KeywordTypeDto
            CreateMap<KeywordType, KeywordTypeDto>();
            CreateMap<KeywordTypeToCreateDto, KeywordType>();
            CreateMap<KeywordTypeToUpdateDto, KeywordType>();

            CreateMap<DocumentTypeGraphType, DocumentType>();
            CreateMap<KeywordGraphType, Keyword>();
            CreateMap<KeywordTypeGraphType, KeywordType>();
        }
    }
}
