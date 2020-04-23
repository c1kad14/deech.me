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

                foreach (XmlNode genre in genres)
                {
                    //book.Title.Genres.Add(new Genre { Code = genre.InnerText });
                }

                if (root.SelectSingleNode("//bk:description/bk:title-info/bk:author/bk:first-name", ns)?.InnerText != null || root.SelectSingleNode("//bk:description/bk:title-info/bk:author/bk:last-name", ns)?.InnerText != null)
                {
                    book.Title.Author = new Person
                    {
                        FirstName = root.SelectSingleNode("//bk:description/bk:title-info/bk:author/bk:first-name", ns)?.InnerText,
                        LastName = root.SelectSingleNode("//bk:description/bk:title-info/bk:author/bk:last-name", ns)?.InnerText,
                        MiddleName = root.SelectSingleNode("//bk:description/bk:title-info/bk:author/bk:middle-name", ns)?.InnerText

                    };
                }

                if (root.SelectSingleNode("//bk:description/bk:title-info/bk:translator/bk:first-name", ns)?.InnerText != null || root.SelectSingleNode("//bk:description/bk:title-info/bk:translator/bk:last-name", ns)?.InnerText != null)
                {
                    book.Title.Translator = new Person
                    {
                        FirstName = root.SelectSingleNode("//bk:description/bk:title-info/bk:translator/bk:first-name", ns)?.InnerText,
                        LastName = root.SelectSingleNode("//bk:description/bk:title-info/bk:translator/bk:last-name", ns)?.InnerText,
                        MiddleName = root.SelectSingleNode("//bk:description/bk:title-info/bk:translator/bk:middle-name", ns)?.InnerText

                    };
                }

                book.Title.Title = root.SelectSingleNode("//bk:description/bk:title-info/bk:book-title", ns)?.InnerText;
                book.Title.Annotation = root.SelectSingleNode("//bk:description/bk:title-info/bk:annotation", ns)?.InnerText;
                book.Title.Date = root.SelectSingleNode("//bk:description/bk:title-info/bk:date", ns)?.InnerText;

                if (root.SelectSingleNode("//bk:description/bk:title-info/bk:lang", ns)?.InnerText != null)
                {
                    book.Title.Language = new Language { Code = root.SelectSingleNode("//bk:description/bk:title-info/bk:lang", ns).InnerText };
                }

                if (root.SelectSingleNode("//bk:description/bk:title-info/bk:source-lang", ns)?.InnerText != null)
                {
                    book.Title.SourceLanguage = new Language { Code = root.SelectSingleNode("//bk:description/bk:title-info/bk:source-language", ns).InnerText };
                }

                book.Publish.BookName = root.SelectSingleNode("//bk:description/bk:publish-info/bk:book-name", ns)?.InnerText;
                book.Publish.City = root.SelectSingleNode("//bk:description/bk:publish-info/bk:city", ns)?.InnerText;
                book.Publish.Publisher = root.SelectSingleNode("//bk:description/bk:publish-info/bk:publisher", ns)?.InnerText;
                book.Publish.Year = root.SelectSingleNode("//bk:description/bk:publish-info/bk:year", ns)?.InnerText;

                book.Content.Content = Encoding.UTF8.GetBytes(root.SelectSingleNode("//bk:body", ns)?.InnerText);
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