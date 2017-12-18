using GraphQLServer.Api.Models.KeywordType;

namespace GraphQLServer.Api.Models.DocumentType
{
    public class DocumentTypeToCreateDto
    {
        public string Name { get; set; }
        public KeywordTypeDto[] KeywordTypes { get; set; }
    }
}
