﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Contexts;
using GraphQLServer.Core.Models;

namespace GraphQLServer.Core.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private DocumentContext _context;
        public DocumentTypeRepository(DocumentContext context)
        {
            _context = context;
        }
        public IEnumerable<DocumentType> GetDocumentTypes() => _context.DocumentTypes.ToList();

        public IEnumerable<DocumentType> GetDocumentTypes(int KeywordTypeId) => _context.DocumentTypes
                                                                                    .Where(dt => dt.DocumentTypeKeywordTypes
                                                                                        .Any(dtkt => dtkt.KeywordTypeId == KeywordTypeId))
                                                                                    .ToList();

        public DocumentType GetDocumentType(int documentTypeId) => _context.DocumentTypes.FirstOrDefault(dt => dt.DocumentTypeId == documentTypeId);

        public DocumentType GetDocumentTypeForDocument(int documentId) => _context.DocumentTypes.FirstOrDefault(dt => dt.Documents.Any(d => d.DocumentId == documentId));
        public void AddDocumentType(DocumentType documentType)
        {
            _context.DocumentTypes.Add(documentType);
        }
        public void UpdateDocumentType(DocumentType documentType)
        {
            _context.DocumentTypes.Update(documentType);
            _context.Entry(documentType).State = EntityState.Modified;
        }

        public void DeleteDocumentType(DocumentType documentType)
        {
            _context.DocumentTypes.Remove(documentType);
        }

        public bool DocumentTypeExists(int documentTypeId) => _context.DocumentTypes.Any(dt => dt.DocumentTypeId == documentTypeId);

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }       
    }
}
