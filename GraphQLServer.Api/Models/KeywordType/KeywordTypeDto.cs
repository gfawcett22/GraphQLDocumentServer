using GraphQLServer.Core.Models;

namespace GraphQLServer.Api.Models.KeywordType
{
    public class KeywordTypeDto
    {
        public int KeywordTypeId { get; set; }
        public string Name { get; set; }
        public bool Invisible { get; set; }
        public bool NotForRetrieval { get; set; }
        public DataType DataType { get; set; }
    }
}
