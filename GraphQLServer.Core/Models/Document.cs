using System.Collections.Generic;

namespace GraphQLServer.Core.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string AutoNameString { get; set; }
        public DocumentType DocumentType { get; set; }
        public ICollection<Keyword> Keywords { get; set; }
    }
}
