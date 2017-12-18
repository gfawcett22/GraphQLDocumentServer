using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string AutoNameString { get; set; }
        public DocumentType DocumentType { get; set; }
        public ICollection<DocumentKeyword> DocumentKeywords { get; set; }
    }
}
