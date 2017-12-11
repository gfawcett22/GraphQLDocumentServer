using GraphQLServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Core.Data
{
    public interface IKeywordRepository
    {
        IEnumerable<Keyword> GetKeywords();
        IEnumerable<Keyword> GetKeywords(int DocumentId);
        Keyword GetKeyword(int KeywordId);
        void AddKeyword(Keyword Keyword);
        void DeleteKeyword(Keyword Keyword);
        void UpdateKeyword(Keyword Keyword);
        bool KeywordExists(int KeywordId);
        bool Save();
    }
}
