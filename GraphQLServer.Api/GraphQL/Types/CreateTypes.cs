using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.GraphQL.Types.Create
{
    public class DocumentCreateInputType : InputObjectGraphType
    {
        public DocumentCreateInputType()
        {
            Name = "DocumentCreateInput";
            Field<NonNullGraphType<StringGraphType>>("autoNameString");
            Field<NonNullGraphType<IntGraphType>>("documentTypeId");
            Field<ListGraphType<KeywordCreateInputType>>("keywords");
        }
    }

    public class DocumentTypeCreateInputType : InputObjectGraphType
    {
        public DocumentTypeCreateInputType()
        {
            Name = "DocumentTypeCreateInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<ListGraphType<IntGraphType>>("keywordTypeIds");
        }
    }

    public class KeywordCreateInputType : InputObjectGraphType
    {
        public KeywordCreateInputType()
        {
            Name = "KeywordCreateInput";
            Field<NonNullGraphType<IntGraphType>>("keywordType");
            Field<NonNullGraphType<StringGraphType>>("value");
        }
    }

    public class KeywordTypeCreateInputType : InputObjectGraphType
    {
        public KeywordTypeCreateInputType()
        {
            Name = "KeywordTypeInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<BooleanGraphType>("invisible");
            Field<BooleanGraphType>("notForRetrieval");
            Field<NonNullGraphType<StringGraphType>>("dataType");
        }
    }
}
