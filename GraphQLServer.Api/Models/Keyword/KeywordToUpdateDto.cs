namespace GraphQLServer.Api.Models.Keyword
{
    public class KeywordToUpdateDto
    {
        public int KeywordId { get; set; }
        public int KeywordTypeId { get; set; }
        public object Value { get; set; }
    }
}
