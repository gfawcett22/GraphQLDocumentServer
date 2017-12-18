using GraphQLServer.Api.Models.Keyword;

namespace GraphQLServer.Api.Models.Document
{
    public class DocumentDto
    {
        public int DocumentId { get; set; }
        public string AutoNameString { get; set; }
        public int DocumentTypeId { get; set; }
        public KeywordDto[] Keywords { get; set; }
    }
}
