using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Core.Models
{
    public class DocumentKeyword
    {
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
    }
}
