using GraphQLServer.Core.Models;
using System.Collections.Generic;

namespace GraphQLServer.Core.Data
{
    public interface IDocumentTypeRepository
    {
        IEnumerable<DocumentType> GetDocumentTypes();
        DocumentType GetDocumentType(int documentTypeId);
        void AddDocumentType(DocumentType documentType);
        void DeleteDocumentType(DocumentType documentType);
        void UpdateDocumentType(DocumentType documentType);
        bool DocumentTypeExists(int documentTypeId);
        bool Save();
    }
}

