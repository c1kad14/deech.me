using System;
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

                var bk = new XmlNamespaceManager(doc.NameTable);
                bk.AddNamespace("bk", "http://www.gribuser.ru/xml/fictionbook/2.0");

                var root = doc.DocumentElement;
                var genres = root.SelectNodes("//bk:description/bk:title-info/bk:genre", bk);
                var authors = root.SelectNodes("//bk:description/bk:title-info/bk:author", bk);
                var translators = root.SelectNodes("//bk:description/bk:title-info/bk:translator", bk);
                var bodies = root.SelectNodes("//bk:body", bk);
                var binary = root.SelectNodes("//bk:binary", bk);

                book.File = file.Name;

                book.TitleInfo.Title = root.SelectSingleNode("//bk:description/bk:title-info/bk:book-title", bk)?.InnerText;
                book.TitleInfo.Annotation = root.SelectSingleNode("//bk:description/bk:title-info/bk:annotation", bk)?.InnerText;
                book.TitleInfo.Date = root.SelectSingleNode("//bk:description/bk:title-info/bk:date", bk)?.InnerText;

                book.PublishInfo.BookName = root.SelectSingleNode("//bk:description/bk:publish-info/bk:book-name", bk)?.InnerText;
                book.PublishInfo.City = root.SelectSingleNode("//bk:description/bk:publish-info/bk:city", bk)?.InnerText;
                book.PublishInfo.Publisher = root.SelectSingleNode("//bk:description/bk:publish-info/bk:publisher", bk)?.InnerText;
                book.PublishInfo.Year = root.SelectSingleNode("//bk:description/bk:publish-info/bk:year", bk)?.InnerText;

                book.CustomInfo.Text = root.SelectSingleNode("//bk:description/bk:custom-info", bk)?.InnerText;

                if (root.SelectSingleNode("//bk:description/bk:title-info/bk:keywords", bk)?.InnerText != null)
                {
                    var keywords = root.SelectSingleNode("//bk:description/bk:title-info/bk:keywords", bk).InnerText.Split(",");

                    foreach (var keyword in keywords)
                    {
                        if (!book.TitleInfo.Keywords.Exists(k => k.Keyword.Code == keyword))
                        {
                            book.TitleInfo.Keywords.Add(new TitleInfoKeyword { TitleInfo = book.TitleInfo, Keyword = new Keyword { Code = keyword.Trim() } });
                        }
                    }
                }

                foreach (XmlNode genre in genres)
                {
                    if (!book.TitleInfo.Genres.Exists(g => g.Genre.Code == genre.InnerText))
                    {
                        book.TitleInfo.Genres.Add(new TitleInfoGenre { TitleInfo = book.TitleInfo, Genre = new Genre { Code = genre.InnerText } });
                    }
                }

                foreach (XmlNode author in authors)
                {
                    book.TitleInfo.Authors.Add(new TitleInfoAuthor
                    {
                        TitleInfo = book.TitleInfo,
                        Author = new Person
                        {
                            FirstName = root.SelectSingleNode("//bk:first-name", bk)?.InnerText,
                            LastName = root.SelectSingleNode("//bk:last-name", bk)?.InnerText,
                            MiddleName = root.SelectSingleNode("//bk:middle-name", bk)?.InnerText
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
                            FirstName = root.SelectSingleNode("//bk:first-name", bk)?.InnerText,
                            LastName = root.SelectSingleNode("//bk:last-name", bk)?.InnerText,
                            MiddleName = root.SelectSingleNode("//bk:middle-name", bk)?.InnerText
                        }
                    });
                }

                if (root.SelectSingleNode("//bk:description/bk:title-info/bk:lang", bk)?.InnerText != null)
                {
                    book.TitleInfo.Language = new Language { Code = root.SelectSingleNode("//bk:description/bk:title-info/bk:lang", bk).InnerText };
                }

                if (root.SelectSingleNode("//bk:description/bk:title-info/bk:source-lang", bk)?.InnerText != null)
                {
                    book.TitleInfo.SourceLanguage = new Language { Code = root.SelectSingleNode("//bk:description/bk:title-info/bk:source-language", bk).InnerText };
                }

                foreach (XmlNode body in bodies)
                {
                    book.Contents.Add(new BookContent
                    {
                        Book = book,
                        Data = Encoding.UTF8.GetBytes(body.InnerXml)
                    });
                }

                foreach (XmlNode bin in binary)
                {
                    if (bin.Attributes["id"].Value == "cover.jpg")
                    {
                        book.TitleInfo.Cover.Data = Encoding.UTF8.GetBytes(bin.InnerXml);
                    }
                    else
                    {
                        book.Images.Add(new Image
                        {
                            Book = book,
                            Data = Encoding.UTF8.GetBytes(bin.InnerXml),
                            Name = bin.Attributes["id"].Value,
                            Type = bin.Attributes["content-type"].Value
                        });
                    }
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