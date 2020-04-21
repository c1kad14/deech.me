using deech.me.data.models;
using Microsoft.EntityFrameworkCore;

namespace deech.me.data.context
{
    public class DeechMeDataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookContent> BookContents { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PublishInfo> PublishInfos { get; set; }
        public DbSet<TitleInfo> TitleInfos { get; set; }
    }
}