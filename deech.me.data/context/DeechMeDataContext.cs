using deech.me.data.entities;
using Microsoft.EntityFrameworkCore;

namespace deech.me.data.context
{
    public class DeechMeDataContext : DbContext
    {
        public DeechMeDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookContent> BookContents { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<CustomInfo> CustomInfos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PublishInfo> PublishInfos { get; set; }
        public DbSet<TitleInfo> TitleInfos { get; set; }
        public DbSet<TitleInfoAuthor> TitleInfoAuthors { get; set; }
        public DbSet<TitleInfoGenre> TitleInfoGenres { get; set; }
        public DbSet<TitleInfoKeyword> TitleInfoKeywords { get; set; }
        public DbSet<TitleInfoTranslator> TitleInfoTranslators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=DeechMeDb;User Id=SA;Password=1Secure*Password1");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TitleInfoAuthor>()
                .HasKey(x => new { x.TitleInfoId, x.AuthorId });

            modelBuilder.Entity<TitleInfoGenre>()
                .HasKey(x => new { x.TitleInfoId, x.GenreCode });

            modelBuilder.Entity<TitleInfoKeyword>()
                .HasKey(x => new { x.TitleInfoId, x.KeywordCode });

            modelBuilder.Entity<TitleInfoTranslator>()
                .HasKey(x => new { x.TitleInfoId, x.TranslatorId });
        }
    }
}