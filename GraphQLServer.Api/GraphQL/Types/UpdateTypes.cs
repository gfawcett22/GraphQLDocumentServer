using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Api.GraphQL.Types.Update
{
    public class UpdateTypes
    {
    }
    public class DocumentUpdateInputType : InputObjectGraphType
    {
        public DocumentUpdateInputType()
        {
            Name = "DocumentUpdateInput";
            Field<NonNullGraphType<IntGraphType>>("id");
            Field<StringGraphType>("autoNameString");
            Field<IntGraphType>("documentTypeId");
            Field<ListGraphType<KeywordUpdateInputType>>("keywords");
        }
    }

    public class DocumentTypeUpdateInputType : InputObjectGraphType
    {
        public DocumentTypeUpdateInputType()
        {
            Name = "DocumentTypeUpdateInput";
            Field<NonNullGraphType<IntGraphType>>("id");
            Field<StringGraphType>("name");
            Field<ListGraphType<IntGraphType>>("keywordTypeIds");
        }
    }

    public class KeywordUpdateInputType : InputObjectGraphType
    {
        public KeywordUpdateInputType()
        {
            Name = "KeywordUpdateInput";
            Field<NonNullGraphType<IntGraphType>>("id");
            Field<IntGraphType>("keywordType");
            Field<StringGraphType>("value");
        }
    }

    public class KeywordTypeUpdateInputType : InputObjectGraphType
    {
        public KeywordTypeUpdateInputType()
        {
            Name = "KeywordTypeUpdateInput";
            Field<NonNullGraphType<IntGraphType>>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<BooleanGraphType>("invisible");
            Field<BooleanGraphType>("notForRetrieval");
            Field<NonNullGraphType<StringGraphType>>("dataType");
        }
    }
}
