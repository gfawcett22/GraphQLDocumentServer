using System.Collections.Generic;

namespace GraphQLServer.Api.Models.DocumentType
{
    public class DocumentTypeToCreateDto
    {
        public string Name { get; set; }
        public ICollection<int> KeywordTypeIds { get; set; }
    }
}
