using System.Collections.Generic;
using System.Threading.Tasks;
using deech.me.data.context;
using deech.me.data.entities;
using Microsoft.EntityFrameworkCore;

namespace deech.me.import
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book>();
            var files = BookReader.GetBooks();

            var parser = new BookParser();
            files.ForEach(b =>
            {
                var book = parser.Parse(b);
                if (book != null)
                {
                    books.Add(book);
                }
            });

            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Server=127.0.0.1,1433;Database=DeechMeDb;User Id=SA;Password=1Secure*Password1");

            foreach (var book in books)
            {
                using (var context = new DeechMeDataContext(builder.Options))
                {
                    // book.Title.Genres.ForEach(async g =>
                    // {
                    //     var genre = await context.Genres.FirstOrDefaultAsync(x => x.Code == g.Code);

                    //     if (genre != null)
                    //     {
                    //         context.Entry(g).State = EntityState.Detached;
                    //     }
                    // });

                    try
                    {
                        if (book.Title.Language?.Code != null)
                        {
                            var language = context.Languages.Find(book.Title.Language.Code);

                            if (language != null)
                            {
                                book.Title.Language = language;
                            }
                        }

                        if (book.Title.SourceLanguage?.Code != null)
                        {
                            var language = context.Languages.Find(book.Title.Language.Code);

                            if (language != null)
                            {
                                book.Title.SourceLanguage = language;
                            }
                        }

                        context.Add(book);
                        context.SaveChanges();
                    }
                    catch (System.Exception ex)
                    {
                        throw;
                    }





                }
            }
        }
    }
}
