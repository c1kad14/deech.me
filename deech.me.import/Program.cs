using System;
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
                    for (int i = 0; i < book.TitleInfo.Genres.Count; i++)
                    {
                        var existingGenre = context.Genres.Find(book.TitleInfo.Genres[i].Genre.Code);

                        if (existingGenre != null)
                        {
                            book.TitleInfo.Genres[i].Genre = existingGenre;
                        }
                    }

                    if (book.TitleInfo.Language?.Code != null)
                    {
                        var language = context.Languages.Find(book.TitleInfo.Language.Code);

                        if (language != null)
                        {
                            book.TitleInfo.Language = language;
                        }
                    }

                    if (book.TitleInfo.SourceLanguage?.Code != null)
                    {
                        var language = context.Languages.Find(book.TitleInfo.Language.Code);

                        if (language != null)
                        {
                            book.TitleInfo.SourceLanguage = language;
                        }
                    }

                    if (book.TitleInfo.Authors.Count > 0)
                    {
                        for (var i = 0; i < book.TitleInfo.Authors.Count; i++)
                        {
                            var author = book.TitleInfo.Authors[i].Author;
                            var exisitngAuthor = await context.Persons.FirstOrDefaultAsync(p => p.FirstName == author.FirstName && p.LastName == author.LastName && p.MiddleName == author.MiddleName);

                            if (exisitngAuthor != null)
                            {
                                book.TitleInfo.Authors[i].Author = exisitngAuthor;
                            }
                        }
                    }

                    if (book.TitleInfo.Translators.Count > 0)
                    {
                        for (var i = 0; i < book.TitleInfo.Translators.Count; i++)
                        {
                            var translator = book.TitleInfo.Translators[i].Translator;
                            var exisitngTranslator = await context.Persons.FirstOrDefaultAsync(p => p.FirstName == translator.FirstName && p.LastName == translator.LastName && p.MiddleName == translator.MiddleName);

                            if (exisitngTranslator != null)
                            {
                                book.TitleInfo.Translators[i].Translator = exisitngTranslator;
                            }
                        }
                    }

                    if (book.TitleInfo.Keywords.Count > 0)
                    {
                        for (var i = 0; i < book.TitleInfo.Keywords.Count; i++)
                        {
                            var keyword = book.TitleInfo.Keywords[i].Keyword;
                            var existingKeyword = context.Keywords.Find(keyword.Code);

                            if (existingKeyword != null)
                            {
                                book.TitleInfo.Keywords[i].Keyword = existingKeyword;
                            }
                        }
                    }

                    try
                    {
                        context.Add(book);
                        context.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        System.Console.WriteLine(book.File);
                    }
                }
            }
        }
    }
}
