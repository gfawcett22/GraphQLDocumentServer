using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.Models
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<DocumentTypeKeywordType> DocumentTypeKeywordTypes { get; set; }
    }
}
