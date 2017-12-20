namespace GraphQLServer.Api.Models.KeywordType
{
    public class KeywordTypeToCreateDto
    {
        public string Name { get; set; }
        public bool Invisible { get; set; }
        public bool NotForRetrieval { get; set; }
        public string DataType { get; set; }
    }
}
