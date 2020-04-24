using System.Collections.Generic;
using System.Threading.Tasks;
using deech.me.data.context;
using deech.me.data.entities;
using Microsoft.EntityFrameworkCore;

namespace deech.me.import
{
    class Program
    {
        static async Task Main(string[] args)
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
                    for (int i = 0; i < book.Title.Genres.Count; i++)
                    {
                        var existingGenre = context.Genres.Find(book.Title.Genres[i].Genre.Code);

                        if (existingGenre != null)
                        {
                            book.Title.Genres[i].Genre = existingGenre;
                        }
                    }

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

                    if (book.Title.Author != null)
                    {
                        var exisitngAuthor = await context.Persons.FirstOrDefaultAsync(p => p.FirstName == book.Title.Author.FirstName && p.LastName == book.Title.Author.LastName && p.MiddleName == book.Title.Author.MiddleName);

                        if (exisitngAuthor != null)
                        {
                            book.Title.Author = exisitngAuthor;
                        }

                    }

                    if (book.Title.Translator != null)
                    {
                        var exisitngTranslator = await context.Persons.FirstOrDefaultAsync(p => p.FirstName == book.Title.Translator.FirstName && p.LastName == book.Title.Translator.LastName && p.MiddleName == book.Title.Translator.MiddleName);

                        if (exisitngTranslator != null)
                        {
                            book.Title.Translator = exisitngTranslator;
                        }
                    }

                    try
                    {
                        context.Add(book);
                        context.SaveChanges();
                    }
                    catch
                    {
                        System.Console.WriteLine(book.File);
                    }
                }
            }
        }
    }
}
