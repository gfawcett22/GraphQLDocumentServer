using GraphQLServer.Core.Contexts;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLServer.Core.Repositories
{
    public class KeywordTypeRepository : IKeywordTypeRepository
    {
        private DocumentContext _context;
        public KeywordTypeRepository(DocumentContext context)
        {
            _context = context;
        }
        public IEnumerable<KeywordType> GetKeywordTypes() => _context.KeywordTypes.ToList();

        public IEnumerable<KeywordType> GetKeywordTypes(int DocumentTypeId) => _context.KeywordTypes.ToList();

        public void AddKeywordType(KeywordType KeywordType)
        {
            _context.KeywordTypes.Add(KeywordType);
        }

        public bool KeywordTypeExists(int KeywordTypeId) => _context.KeywordTypes.Any(d => d.KeywordTypeId == KeywordTypeId);

        public KeywordType GetKeywordType(int KeywordTypeId) => _context.KeywordTypes.FirstOrDefault(d => d.KeywordTypeId == KeywordTypeId);

        public void UpdateKeywordType(KeywordType KeywordType)
        {
            _context.Update(KeywordType);
            _context.Entry(KeywordType).State = EntityState.Modified;
        }

        public void DeleteKeywordType(KeywordType KeywordType)
        {
            _context.KeywordTypes.Remove(KeywordType);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }


    }
}
