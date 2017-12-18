using GraphQLServer.Core.Contexts;
using GraphQLServer.Core.Models;
using System.Collections.Generic;

namespace GraphQLServer.Data.Seed
{
    public static class DocumentContextSeeder
    {
        public static void Seed(DocumentContext db)
        {
            db.Database.EnsureCreated();

            // Keyword types
            var keywordTypeList = new List<KeywordType>
            {
                new KeywordType {Name="PO Number", Invisible=false, NotForRetrieval=false, DataType=DataType.AlphaNumeric },
                new KeywordType {Name="PO Amount", Invisible=false, NotForRetrieval=false, DataType=DataType.Numeric},
                new KeywordType {Name="Vendor #", Invisible=false, NotForRetrieval=false, DataType=DataType.AlphaNumeric},
                new KeywordType {Name="Check Amount", Invisible=false, NotForRetrieval=false, DataType=DataType.LongNumeric}
            };

            db.KeywordTypes.AddRange(keywordTypeList);
            // Document Types
            var docTypeList = new List<DocumentType>
            {
                new DocumentType {Name="AP - Checks" },
                new DocumentType {Name="AP - Order" },
                new DocumentType {Name="AP - Packing Slip" },
                new DocumentType {Name="AP - Purchase Order" }
            };
            db.DocumentTypes.AddRange(docTypeList);
            // Keywords
            var keywordList = new List<Keyword>
            {
                new Keyword {KeywordType=keywordTypeList[0], Value="123432" },
                new Keyword {KeywordType=keywordTypeList[0], Value="1233ADGED"},
                new Keyword {KeywordType=keywordTypeList[1], Value="3333"},
                new Keyword {KeywordType=keywordTypeList[2], Value="LJKH786"},
                new Keyword {KeywordType=keywordTypeList[1], Value="987654"},
                new Keyword {KeywordType=keywordTypeList[0], Value="1233ADGED"},
                new Keyword {KeywordType=keywordTypeList[2], Value="LKJ687"},
                new Keyword {KeywordType=keywordTypeList[1], Value="1255847"},
                new Keyword {KeywordType=keywordTypeList[3], Value="12345678909875641"}
            };
            db.Keywords.AddRange(keywordList);
            // Documents
            var docList = new List<Document>
            {
                new Document {AutoNameString = "This is the first document", DocumentType=docTypeList[0] },
                new Document {AutoNameString = "This is the second document", DocumentType=docTypeList[1] },
                new Document {AutoNameString = "This is the third document", DocumentType=docTypeList[2] },
                new Document {AutoNameString = "This is the fourth document", DocumentType=docTypeList[3] },
                new Document {AutoNameString = "This is the fifth document", DocumentType=docTypeList[0] }
            };
            db.Documents.AddRange(docList);

            // Document Type Keyword Type Join
            db.Add(new DocumentTypeKeywordType { DocumentType = docTypeList[0], KeywordType = keywordTypeList[0] });
            db.Add(new DocumentTypeKeywordType { DocumentType = docTypeList[1], KeywordType = keywordTypeList[0] });
            db.Add(new DocumentTypeKeywordType { DocumentType = docTypeList[1], KeywordType = keywordTypeList[2] });
            db.Add(new DocumentTypeKeywordType { DocumentType = docTypeList[2], KeywordType = keywordTypeList[1] });
            db.Add(new DocumentTypeKeywordType { DocumentType = docTypeList[3], KeywordType = keywordTypeList[1] });
            db.Add(new DocumentTypeKeywordType { DocumentType = docTypeList[3], KeywordType = keywordTypeList[3] });
            // Document Keyword Join
            db.AddRange(
                new DocumentKeyword { Document = docList[0], Keyword = keywordList[0] },
                new DocumentKeyword { Document = docList[0], Keyword = keywordList[1] },
                new DocumentKeyword { Document = docList[1], Keyword = keywordList[0] },
                new DocumentKeyword { Document = docList[1], Keyword = keywordList[1] },
                new DocumentKeyword { Document = docList[1], Keyword = keywordList[3] },
                new DocumentKeyword { Document = docList[2], Keyword = keywordList[2] },
                new DocumentKeyword { Document = docList[2], Keyword = keywordList[4] },
                new DocumentKeyword { Document = docList[2], Keyword = keywordList[7] },
                new DocumentKeyword { Document = docList[3], Keyword = keywordList[8] },
                new DocumentKeyword { Document = docList[3], Keyword = keywordList[4] },
                new DocumentKeyword { Document = docList[4], Keyword = keywordList[0] },
                new DocumentKeyword { Document = docList[4], Keyword = keywordList[1] }
            );

            db.SaveChanges();
        }
    }
}
