﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.Core.Models
{
    public class Keyword
    {
        public int KeywordId { get; set; }
        public KeywordType KeywordType { get; set; }
        public string Value { get; set; }
        public Document Document { get; set; }
        public override string ToString() => Value;

    }
}
