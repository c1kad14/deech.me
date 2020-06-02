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
        public DbSet<FavouriteBook> FavouriteBooks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<PublishInfo> PublishInfos { get; set; }
        public DbSet<ReadingProgress> ReadingProgresses { get; set; }
        public DbSet<TitleInfo> TitleInfos { get; set; }
        public DbSet<TitleInfoAuthor> TitleInfoAuthors { get; set; }
        public DbSet<TitleInfoGenre> TitleInfoGenres { get; set; }
        public DbSet<TitleInfoKeyword> TitleInfoKeywords { get; set; }
        public DbSet<TitleInfoTranslator> TitleInfoTranslators { get; set; }
        public DbSet<Translator> Translators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=DeechMeDb;User Id=SA;Password=1Secure*Password1");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookmark>()
                .HasKey(b => new { b.ParagraphId, b.UserId });

            modelBuilder.Entity<FavouriteBook>()
                .HasKey(fb => new { fb.BookId, fb.UserId });

            modelBuilder.Entity<Note>()
                .HasKey(n => new { n.ParagraphId, n.UserId });

            modelBuilder.Entity<ReadingProgress>()
                .HasKey(rp => new { rp.BookId, rp.UserId });

            modelBuilder.Entity<TitleInfoGenre>()
                .HasKey(t => new { t.TitleInfoId, t.GenreCode });

            modelBuilder.Entity<TitleInfoKeyword>()
                .HasKey(t => new { t.TitleInfoId, t.KeywordCode });

            modelBuilder.Entity<Comment>().HasOne(x => x.Associated).WithMany().HasForeignKey(x => x.AssociatedId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}