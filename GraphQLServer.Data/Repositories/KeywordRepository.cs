using GraphQLServer.Core.Contexts;
using GraphQLServer.Core.Data;
using GraphQLServer.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLServer.Core.Repositories
{
    public class KeywordRepository : IKeywordRepository
    {
        private DocumentContext _context;
        public KeywordRepository(DocumentContext context)
        {
            _context = context;
        }
        public IEnumerable<Keyword> GetKeywords() => _context.Keywords.ToList();

        public IEnumerable<Keyword> GetKeywords(int DocumentId) => _context.Keywords.Where(k => k.DocumentKeywords.Any(dk => dk.DocumentId == DocumentId));

        public void AddKeyword(Keyword Keyword)
        {
            _context.Keywords.Add(Keyword);
        }

        public bool KeywordExists(int KeywordId) => _context.Keywords.Any(d => d.KeywordId == KeywordId);

        public Keyword GetKeyword(int KeywordId) => _context.Keywords.FirstOrDefault(d => d.KeywordId == KeywordId);

        public void UpdateKeyword(Keyword Keyword)
        {
            _context.Update(Keyword);
            _context.Entry(Keyword).State = EntityState.Modified;
        }

        public void DeleteKeyword(Keyword Keyword)
        {
            _context.Keywords.Remove(Keyword);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
