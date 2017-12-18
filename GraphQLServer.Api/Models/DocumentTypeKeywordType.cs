using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.Models
{
    public class DocumentTypeKeywordType
    {
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public int KeywordTypeId { get; set; }
        public KeywordType KeywordType { get; set; }
    }
}
