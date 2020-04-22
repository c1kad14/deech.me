using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
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

                var description = doc.GetElementsByTagName("description")[0].OwnerDocument;
                var titleInfo = description.GetElementsByTagName("title-info")[0].OwnerDocument;
                var publishInfo = description.GetElementsByTagName("publish-info")[0].OwnerDocument;
                var body = description.GetElementsByTagName("body")[0].OwnerDocument;
                var author = titleInfo.GetElementsByTagName("author")[0].OwnerDocument;

                book.Title.Genre.Code = titleInfo.GetElementsByTagName("genre").Count > 0 ? titleInfo.GetElementsByTagName("genre")[0].InnerText : null;

                book.Title.Author.FirstName = author.GetElementsByTagName("first-name").Count > 0 ? author.GetElementsByTagName("first-name")[0].InnerText : null;
                book.Title.Author.LastName = author.GetElementsByTagName("last-name").Count > 0 ? author.GetElementsByTagName("last-name")[0].InnerText : null;

                book.Title.Title = titleInfo.GetElementsByTagName("book-title").Count > 0 ? titleInfo.GetElementsByTagName("book-title")[0].InnerText : null;
                book.Title.Annotation = titleInfo.GetElementsByTagName("annotation").Count > 0 ? titleInfo.GetElementsByTagName("annotation")[0].InnerXml : null;
                book.Title.Date = titleInfo.GetElementsByTagName("date").Count > 0 ? titleInfo.GetElementsByTagName("date")[0].InnerXml : null;
                book.Title.Language.Code = titleInfo.GetElementsByTagName("language").Count > 0 ? titleInfo.GetElementsByTagName("language")[0].InnerXml : null;
                book.Title.SourceLanguage.Code = titleInfo.GetElementsByTagName("source-language").Count > 0 ? titleInfo.GetElementsByTagName("source-language")[0].InnerXml : null;

                book.Publish.BookName = publishInfo.GetElementsByTagName("book-name").Count > 0 ? publishInfo.GetElementsByTagName("book-name")[0].InnerText : null;
                book.Publish.Publisher = publishInfo.GetElementsByTagName("publisher").Count > 0 ? publishInfo.GetElementsByTagName("publisher")[0].InnerText : null;
                book.Publish.Year = publishInfo.GetElementsByTagName("year").Count > 0 ? publishInfo.GetElementsByTagName("year")[0].InnerText : null;

                book.Content.Content = Encoding.UTF8.GetBytes(body.InnerXml);
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