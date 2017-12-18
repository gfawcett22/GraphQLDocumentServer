namespace GraphQLServer.Api.Models.Document
{
    public class DocumentToCreateDto
    {
        public string AutoNameString { get; set; }
        public int DocumentTypeId { get; set; }
        public int[] KeywordIds { get; set; }
    }
}
