using GraphQLServer.Api.Models;
using System.Collections.Generic;


namespace GraphQLServer.Api.Repositories
{
    public interface IDocumentRepository
    {
        IEnumerable<Document> GetDocuments();
        Document GetDocument(int documentId);
        void AddDocument(Document document);
        void DeleteDocument(Document document);
        void UpdateDocument(Document document);
        bool DocumentExists(int documentId);
        bool Save();
    }
}
