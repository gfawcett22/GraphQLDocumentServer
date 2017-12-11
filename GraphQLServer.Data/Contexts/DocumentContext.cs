using Microsoft.EntityFrameworkCore;

using GraphQLServer.Core.Models;

namespace GraphQLServer.Core.Contexts
{
    public class DocumentContext : DbContext
    {
        public DocumentContext(DbContextOptions<DocumentContext> options) : base(options) { }

        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<KeywordType> KeywordTypes { get; set; }
        public DbSet<Keyword> Keywords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentTypeKeywordType>()
                .HasKey(dtkt => new { dtkt.DocumentTypeId, dtkt.KeywordTypeId });

            modelBuilder.Entity<DocumentTypeKeywordType>()
                .HasOne(dtkt => dtkt.DocumentType)
                .WithMany(dk => dk.DocumentTypeKeywordTypes);
            //.HasForeignKey(dtkt => dtkt.DocumentTypeId);

            modelBuilder.Entity<DocumentTypeKeywordType>()
                .HasOne(dtkt => dtkt.KeywordType)
                .WithMany(dk => dk.DocumentTypeKeywordTypes);
            //.HasForeignKey(dtkt => dtkt.KeywordTypeId);

            modelBuilder.Entity<DocumentKeyword>()
                .HasKey(dk => new { dk.DocumentId, dk.KeywordId });

            modelBuilder.Entity<DocumentKeyword>()
                .HasOne(dk => dk.Document)
                .WithMany(d => d.DocumentKeywords);
            //.HasForeignKey(dk => dk.DocumentId);

            modelBuilder.Entity<DocumentKeyword>()
                .HasOne(dk => dk.Keyword)
                .WithMany(d => d.DocumentKeywords);
            //.HasForeignKey(dk => dk.KeywordId);
        }
    }
}
