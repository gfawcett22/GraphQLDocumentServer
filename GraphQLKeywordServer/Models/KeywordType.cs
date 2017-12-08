using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.Models
{
    public class KeywordType
    {
        public int KeywordTypeId { get; set; }
        public string Name { get; set; }
        public bool Invisible { get; set; }
        public bool NotForRetrieval { get; set; }
        public DataType DataType { get; set; }
        public ICollection<DocumentTypeKeywordType> DocumentTypeKeywordTypes { get; set; }
    }

    public enum DataType
    {
        AlphaNumeric,
        Numeric,
        LongNumeric
    }
}
