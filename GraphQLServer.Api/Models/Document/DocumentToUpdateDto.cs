using GraphQLServer.Api.Models.Keyword;
using System.Collections.Generic;

namespace GraphQLServer.Api.Models.Document
{
    public class DocumentToUpdateDto
    {
        public string AutoNameString { get; set; }
        public int DocumentTypeId { get; set; }
        public IEnumerable<KeywordToUpdateDto> Keywords { get; set; }
    }
}
