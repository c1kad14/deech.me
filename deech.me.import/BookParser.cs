using System.IO;
using System.Text;
using System.Xml;
using deech.me.data.entities;
using deech.me.import.abstractions;

namespace deech.me.import
{
    public class BookParser : IParser
    {
        public static int ExceptionCount { get; set; }
        public Book Parse(FileInfo file)
        {
            var book = new Book();
            try
            {
                var doc = new XmlDocument();
                doc.Load(file.FullName);

                var ns = new XmlNamespaceManager(doc.NameTable);
                ns.AddNamespace("bk", "http://www.gribuser.ru/xml/fictionbook/2.0");

                var root = doc.DocumentElement;
                var genres = root.SelectNodes("//bk:description/bk:title-info/bk:genre", ns);
                var authors = root.SelectNodes("//bk:description/bk:title-info/bk:author", ns);
                var translators = root.SelectNodes("//bk:description/bk:title-info/bk:translator", ns);
                var bodyList = root.SelectNodes("//bk:body", ns);

                book.File = file.Name;

                book.TitleInfo.Title = root.SelectSingleNode("//bk:description/bk:title-info/bk:book-title", ns)?.InnerText;
                book.TitleInfo.Annotation = root.SelectSingleNode("//bk:description/bk:title-info/bk:annotation", ns)?.InnerText;
                book.TitleInfo.Date = root.SelectSingleNode("//bk:description/bk:title-info/bk:date", ns)?.InnerText;

                foreach (XmlNode genre in genres)
                {
                    book.TitleInfo.Genres.Add(new TitleInfoGenre { TitleInfo = book.TitleInfo, Genre = new Genre { Code = genre.InnerText } });
                }

                foreach (XmlNode author in authors)
                {
                    book.TitleInfo.Authors.Add(new TitleInfoAuthor
                    {
                        TitleInfo = book.TitleInfo,
                        Author = new Person
                        {
                            FirstName = root.SelectSingleNode("//bk:first-name", ns)?.InnerText,
                            LastName = root.SelectSingleNode("//bk:last-name", ns)?.InnerText,
                            MiddleName = root.SelectSingleNode("//bk:middle-name", ns)?.InnerText
                        }
                    });
                }

                foreach (XmlNode translator in translators)
                {
                    book.TitleInfo.Translators.Add(new TitleInfoTranslator
                    {
                        TitleInfo = book.TitleInfo,
                        Translator = new Person
                        {
                            FirstName = root.SelectSingleNode("//bk:first-name", ns)?.InnerText,
                            LastName = root.SelectSingleNode("//bk:last-name", ns)?.InnerText,
                            MiddleName = root.SelectSingleNode("//bk:middle-name", ns)?.InnerText
                        }
                    });
                }

                if (root.SelectSingleNode("//bk:description/bk:title-info/bk:lang", ns)?.InnerText != null)
                {
                    book.TitleInfo.Language = new Language { Code = root.SelectSingleNode("//bk:description/bk:title-info/bk:lang", ns).InnerText };
                }

                if (root.SelectSingleNode("//bk:description/bk:title-info/bk:source-lang", ns)?.InnerText != null)
                {
                    book.TitleInfo.SourceLanguage = new Language { Code = root.SelectSingleNode("//bk:description/bk:title-info/bk:source-language", ns).InnerText };
                }

                book.PublishInfo.BookName = root.SelectSingleNode("//bk:description/bk:publish-info/bk:book-name", ns)?.InnerText;
                book.PublishInfo.City = root.SelectSingleNode("//bk:description/bk:publish-info/bk:city", ns)?.InnerText;
                book.PublishInfo.Publisher = root.SelectSingleNode("//bk:description/bk:publish-info/bk:publisher", ns)?.InnerText;
                book.PublishInfo.Year = root.SelectSingleNode("//bk:description/bk:publish-info/bk:year", ns)?.InnerText;


                foreach (XmlNode body in bodyList)
                {
                    book.Contents.Add(new BookContent
                    {
                        Book = book,
                        Data = Encoding.UTF8.GetBytes(body.InnerXml)
                    });
                }
            }
            catch
            {
                ExceptionCount++;
                return null;
            }

            return book;
        }
    }
}