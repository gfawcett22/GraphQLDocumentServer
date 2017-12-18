using System.Collections.Generic;

namespace GraphQLServer.Core.Models
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
