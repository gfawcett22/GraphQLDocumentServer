using GraphQLServer.Api.Models.Keyword;
using System.Collections.Generic;

namespace GraphQLServer.Api.Models.Document
{
    public class DocumentToCreateDto
    {
        public string AutoNameString { get; set; }
        public int DocumentTypeId { get; set; }
        public ICollection<KeywordToCreateDto> Keywords { get; set; }
    }
}
