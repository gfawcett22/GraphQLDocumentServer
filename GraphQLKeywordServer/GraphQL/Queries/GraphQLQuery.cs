using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLServer.Api.GraphQL.Queries
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; } = "Query";
        public string NamedQuery { get; set; } = "Document Query";
        public string Query { get; set; }
        public string Variables { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine();
            if (!string.IsNullOrWhiteSpace(OperationName))
            {
                builder.AppendLine($"OperationName = {OperationName}");
            }
            if (!string.IsNullOrWhiteSpace(NamedQuery))
            {
                builder.AppendLine($"NamedQuery = {NamedQuery}");
            }
            if (!string.IsNullOrWhiteSpace(Query))
            {
                builder.AppendLine($"Query = {Query}");
            }
            if (!string.IsNullOrWhiteSpace(Variables))
            {
                builder.AppendLine($"Variables = {Variables}");
            }

            return builder.ToString();
        }
    }
}
