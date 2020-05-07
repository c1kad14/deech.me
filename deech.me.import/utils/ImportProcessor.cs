using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using deech.me.data.context;
using deech.me.data.entities;
using deech.me.import.abstractions;
using deech.me.import.models;

namespace deech.me.import.utils
{
    public class ImportProcessor : IImportProcessor
    {
        private DbContextOptions _options;

        public ImportProcessor(DbContextOptions options)
        {
            this._options = options;
        }

        public async Task Process(Book book)
        {
            using (var context = new DeechMeDataContext(this._options))
            {
                if (book.TitleInfo.Genres?.Count > 0)
                {
                    for (int i = 0; i < book.TitleInfo.Genres.Count; i++)
                    {
                        var existingGenre = context.Genres.Find(book.TitleInfo.Genres[i].Genre.Code);

                        if (existingGenre != null)
                        {
                            book.TitleInfo.Genres[i].Genre = existingGenre;
                        }
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

                if (book.TitleInfo.Authors?.Count > 0)
                {
                    for (var i = 0; i < book.TitleInfo.Authors.Count; i++)
                    {
                        var author = book.TitleInfo.Authors[i].Author;
                        var exisitngAuthor = await context.Authors.FirstOrDefaultAsync(p => p.FirstName == author.FirstName && p.LastName == author.LastName && p.MiddleName == author.MiddleName);

                        if (exisitngAuthor != null)
                        {
                            book.TitleInfo.Authors[i].Author = exisitngAuthor;
                        }
                    }
                }

                if (book.TitleInfo.Translators?.Count > 0)
                {
                    for (var i = 0; i < book.TitleInfo.Translators.Count; i++)
                    {
                        var translator = book.TitleInfo.Translators[i].Translator;
                        var exisitngTranslator = await context.Translators.FirstOrDefaultAsync(p => p.FirstName == translator.FirstName && p.LastName == translator.LastName && p.MiddleName == translator.MiddleName);

                        if (exisitngTranslator != null)
                        {
                            book.TitleInfo.Translators[i].Translator = exisitngTranslator;
                        }
                    }
                }

                if (book.TitleInfo.Keywords?.Count > 0)
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

                    var file = $"{Configuration.Instance.ImportFolder}/{book.File}.fb2";
                    var destinationPath = new StringBuilder(file).Replace(Configuration.Instance.ImportFolder, $"{Configuration.Instance.ProcessedFolder}/{book.File}");

                    var fileInfo = new FileInfo(file);
                    fileInfo.MoveTo($"{destinationPath}");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"*** EXCEPTION ({book.File}) ***");
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine("----------------------");
                    System.Console.WriteLine(ex.InnerException);
                    System.Console.WriteLine("*** END ***");
                }
            }
        }
    }
}