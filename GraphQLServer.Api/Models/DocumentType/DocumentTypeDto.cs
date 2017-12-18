using GraphQLServer.Api.Models.KeywordType;

namespace GraphQLServer.Api.Models.DocumentType
{
    public class DocumentTypeDto
    {
        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
        public KeywordTypeDto[] Keywords { get; set; }
    }
}
