using GraphQL.Types;
using GraphQLServer.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.GraphQL.Types
{
    public class DocumentTypeType : ObjectGraphType<Models.DocumentType>
    {
        public DocumentTypeType()
        {
            Field(x => x.DocumentTypeId).Name("Id").Description("The Id of the Document Type");
            Field(x => x.Name).Description("The Name of the Document Type");
            Field<ListGraphType<KeywordTypeType>>("keywordTypes", 
                resolve: context => context.Source.DocumentTypeKeywordTypes.Select(dtkt => dtkt.KeywordType).ToList());
            Field<ListGraphType<DocumentType>>("documents", 
                resolve: context => context.Source.Documents.ToList());
        }
    }
}
