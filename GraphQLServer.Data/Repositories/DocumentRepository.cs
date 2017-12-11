using GraphQLServer.Core.Contexts;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLServer.Core.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private DocumentContext _context;
        public DocumentRepository(DocumentContext context)
        {
            _context = context;
        }
        public IEnumerable<Document> GetDocuments() => _context.Documents.ToList();
                                                                    //.Include(d => d.DocumentType)
                                                                    //.Include(d => d.DocumentKeywords)
                                                                    //.ThenInclude(dk => dk.Keyword)
                                                                    //.ThenInclude(k => k.KeywordType)
                                                                    //.ToList();

        public void AddDocument(Document document)
        {
            _context.Documents.Add(document);
        }

        public bool DocumentExists(int documentId) => _context.Documents.Any(d => d.DocumentId == documentId);

        public Document GetDocument(int documentId) => _context.Documents
                                                                    //.Include(d => d.DocumentType)
                                                                    //.Include(d => d.DocumentKeywords)
                                                                    //.ThenInclude(dk => dk.Keyword)
                                                                    //.ThenInclude(k => k.KeywordType)
                                                                    .FirstOrDefault(d => d.DocumentId == documentId);
        public void UpdateDocument(Document document)
        {
            _context.Update(document);
            _context.Entry(document).State = EntityState.Modified;
        }

        public void DeleteDocument(Document document)
        {
            _context.Documents.Remove(document);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }


    }
}
