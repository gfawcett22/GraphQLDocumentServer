using GraphQLServer.Core.Models;
using System.Collections.Generic;

namespace GraphQLServer.Core.Data
{
    public interface IKeywordTypeRepository
    {
        IEnumerable<KeywordType> GetKeywordTypes();
        IEnumerable<KeywordType> GetKeywordTypes(int DocumentTypeId);
        KeywordType GetKeywordType(int KeywordTypeId);
        void AddKeywordType(KeywordType KeywordType);
        void DeleteKeywordType(KeywordType KeywordType);
        void UpdateKeywordType(KeywordType KeywordType);
        bool KeywordTypeExists(int KeywordTypeId);
        bool Save();
    }
}
