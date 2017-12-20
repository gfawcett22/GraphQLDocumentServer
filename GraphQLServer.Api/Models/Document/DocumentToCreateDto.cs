using System.Collections.Generic;

namespace GraphQLServer.Api.Models.Document
{
    public class DocumentToCreateDto
    {
        public string AutoNameString { get; set; }
        public int DocumentTypeId { get; set; }
        public ICollection<int> KeywordIds { get; set; }
    }
}
