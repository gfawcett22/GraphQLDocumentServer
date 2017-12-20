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
                .WithMany(dk => dk.DocumentTypeKeywordTypes)
                .HasForeignKey(dtkt => dtkt.DocumentTypeId);

            modelBuilder.Entity<DocumentTypeKeywordType>()
                .HasOne(dtkt => dtkt.KeywordType)
                .WithMany(dk => dk.DocumentTypeKeywordTypes)
                .HasForeignKey(dtkt => dtkt.KeywordTypeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
