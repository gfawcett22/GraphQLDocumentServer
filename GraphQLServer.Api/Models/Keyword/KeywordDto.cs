using GraphQLServer.Api.Models.KeywordType;

namespace GraphQLServer.Api.Models.Keyword
{
    public class KeywordDto
    {
        public int KeywordId { get; set; }
        public KeywordTypeDto KeywordType { get; set; }
        public string Value { get; set; }
    }
}
