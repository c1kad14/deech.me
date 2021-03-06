using Microsoft.EntityFrameworkCore;

using deech.me.data.entities;

namespace deech.me.data.context
{
    public class DeechMeDataContext : DbContext
    {
        public DeechMeDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Annotation> Annotations { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookCollection> BookCollections { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Citation> Citations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CustomInfo> CustomInfos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<PublishInfo> PublishInfos { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<TitleInfo> TitleInfos { get; set; }
        public DbSet<TitleInfoAuthor> TitleInfoAuthors { get; set; }
        public DbSet<TitleInfoGenre> TitleInfoGenres { get; set; }
        public DbSet<TitleInfoKeyword> TitleInfoKeywords { get; set; }
        public DbSet<TitleInfoTranslator> TitleInfoTranslators { get; set; }
        public DbSet<Translator> Translators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=DeechMeDb;User Id=sa;Password=1Secure*Password1");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookmark>()
                .HasKey(b => new { b.ParagraphId, b.UserBookId });

            modelBuilder.Entity<Citation>()
                .HasIndex(n => new { n.ParagraphId, n.UserBookId });

            modelBuilder.Entity<Note>()
                .HasKey(n => new { n.ParagraphId, n.UserBookId });

            modelBuilder.Entity<UserBook>()
                .HasIndex(rp => new { rp.BookId, rp.UserId });

            modelBuilder.Entity<TitleInfoGenre>()
                .HasKey(t => new { t.TitleInfoId, t.GenreCode });

            modelBuilder.Entity<TitleInfoKeyword>()
                .HasKey(t => new { t.TitleInfoId, t.KeywordCode });

            modelBuilder.Entity<Bookmark>().HasOne(x => x.UserBook).WithMany(x => x.Bookmarks).HasForeignKey(x => x.UserBookId).OnDelete(DeleteBehavior.NoAction).IsRequired();

            modelBuilder.Entity<Citation>().HasOne(x => x.UserBook).WithMany(x => x.Citations).HasForeignKey(x => x.UserBookId).OnDelete(DeleteBehavior.NoAction).IsRequired();

            modelBuilder.Entity<Note>().HasOne(x => x.UserBook).WithMany(x => x.Notes).HasForeignKey(x => x.UserBookId).OnDelete(DeleteBehavior.NoAction).IsRequired();

            modelBuilder.Entity<Comment>().HasOne(x => x.Associated).WithMany().HasForeignKey(x => x.AssociatedId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}