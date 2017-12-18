﻿using GraphQLServer.Api.Models.KeywordType;

namespace GraphQLServer.Api.Models.DocumentType
{
    public class DocumentTypeToUpdateDto
    {
        public string Name { get; set; }
        public KeywordTypeDto[] KeywordTypes { get; set; }
    }
}
