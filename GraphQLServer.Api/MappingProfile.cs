using AutoMapper;
using GraphQLServer.Api.GraphQL.Types;
using GraphQLServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DocumentInputType, Document>();
                //.ForMember(dest => dest.AutoNameString, opt => opt.MapFrom(src => src.))
            CreateMap<DocumentTypeGraphType, DocumentType>();
            CreateMap<KeywordGraphType, Keyword>();
            CreateMap<KeywordTypeGraphType, KeywordType>();
        }
    }
}
