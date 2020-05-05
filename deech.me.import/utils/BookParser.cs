using System;
using System.IO;
using System.Text;
using System.Xml;

using deech.me.data.entities;
using deech.me.import.abstractions;
using deech.me.import.models;

namespace deech.me.import.utils
{
    public class BookParser : IBookParser
    {
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
                var cover = root.SelectSingleNode("//bk:description/bk:title-info/bk:coverpage/bk:image", bk)?.Attributes[0]?.Value?.Replace("#", "");
                var genres = root.SelectNodes("//bk:description/bk:title-info/bk:genre", bk);
                var authors = root.SelectNodes("//bk:description/bk:title-info/bk:author", bk);
                var translators = root.SelectNodes("//bk:description/bk:title-info/bk:translator", bk);
                var bodies = root.SelectNodes("//bk:body", bk);
                var binary = root.SelectNodes("//bk:binary", bk);
                var bookId = file.Name.Remove(file.Name.IndexOf(".fb2"), 4);
                var directory = $"{Configuration.Instance.ProcessedFolder}/{bookId}";

                book.File = bookId;

                book.TitleInfo = new TitleInfo
                {
                    Title = root.SelectSingleNode("//bk:description/bk:title-info/bk:book-title", bk)?.InnerText,
                    Date = root.SelectSingleNode("//bk:description/bk:title-info/bk:date", bk)?.InnerText,
                };

                if (!string.IsNullOrEmpty(root.SelectSingleNode("//bk:description/bk:title-info/bk:annotation", bk)?.InnerText))
                {
                    book.TitleInfo.Annotation = new Annotation { Text = root.SelectSingleNode("//bk:description/bk:title-info/bk:annotation", bk)?.InnerText };
                }

                foreach (XmlNode genre in genres)
                {
                    if (!book.TitleInfo.Genres.Exists(g => g.Genre.Code == genre.InnerText))
                    {
                        book.TitleInfo.Genres.Add(new TitleInfoGenre { TitleInfo = book.TitleInfo, Genre = new Genre { Code = genre.InnerText } });
                    }
                }

                if (root.SelectSingleNode("//bk:description/bk:title-info/bk:keywords", bk)?.InnerText != null)
                {
                    var keywords = root.SelectSingleNode("//bk:description/bk:title-info/bk:keywords", bk).InnerText.Split(",");

                    foreach (var keyword in keywords)
                    {
                        if (!book.TitleInfo.Keywords.Exists(k => k.Keyword.Code == keyword.Trim()))
                        {
                            book.TitleInfo.Keywords.Add(new TitleInfoKeyword { TitleInfo = book.TitleInfo, Keyword = new Keyword { Code = keyword.Trim() } });
                        }
                    }
                }

                foreach (XmlNode author in authors)
                {
                    book.TitleInfo.Authors.Add(new TitleInfoAuthor
                    {
                        TitleInfo = book.TitleInfo,
                        Author = new Author
                        {
                            FirstName = author["first-name"]?.InnerText,
                            LastName = author["last-name"]?.InnerText,
                            MiddleName = author["middle-name"]?.InnerText,
                            Nickname = author["nickname"]?.InnerText
                        }
                    });
                }

                foreach (XmlNode translator in translators)
                {
                    book.TitleInfo.Translators.Add(new TitleInfoTranslator
                    {
                        TitleInfo = book.TitleInfo,
                        Translator = new Translator
                        {
                            FirstName = translator["first-name"]?.InnerText,
                            LastName = translator["last-name"]?.InnerText,
                            MiddleName = translator["middle-name"]?.InnerText,
                            Nickname = translator["nickname"]?.InnerText,
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

                if (!string.IsNullOrEmpty(root.SelectSingleNode("//bk:description/bk:publish-info", bk)?.InnerText))
                {
                    book.PublishInfo = new PublishInfo
                    {
                        City = root.SelectSingleNode("//bk:description/bk:publish-info/bk:city", bk)?.InnerText,
                        Publisher = root.SelectSingleNode("//bk:description/bk:publish-info/bk:publisher", bk)?.InnerText,
                        Year = root.SelectSingleNode("//bk:description/bk:publish-info/bk:year", bk)?.InnerText,
                        BookName = root.SelectSingleNode("//bk:description/bk:publish-info/bk:book-name", bk)?.InnerText
                    };
                }

                if (!string.IsNullOrEmpty(root.SelectSingleNode("//bk:description/bk:custom-info", bk)?.InnerText))
                {
                    book.CustomInfo = new CustomInfo { Text = root.SelectSingleNode("//bk:description/bk:custom-info", bk)?.InnerText };
                }

                foreach (XmlNode body in bodies)
                {
                    XmlNodeList paragraphs = body.SelectNodes("//bk:p", bk);
                    var counter = 1;

                    foreach (XmlNode paragraph in paragraphs)
                    {
                        XmlAttribute attr = doc.CreateAttribute("pid");
                        attr.Value = $"{bookId}_{counter++}";
                        paragraph.Attributes.Append(attr);
                    }

                    book.Contents.Add(new BookContent
                    {
                        Book = book,
                        Data = Encoding.UTF8.GetBytes(body.InnerXml)
                    });
                }

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                foreach (XmlNode bin in binary)
                {
                    if (!string.IsNullOrEmpty(bin.Attributes["id"].Value))
                    {

                        var filePath = $"{directory}/{bin.Attributes["id"].Value}";

                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }

                        using (var imageFile = new FileStream(filePath, FileMode.Create))
                        {
                            var imgBase64String = Convert.FromBase64String(bin.InnerXml);
                            imageFile.Write(imgBase64String, 0, imgBase64String.Length);
                            imageFile.Flush();
                        }

                        if (bin.Attributes["id"].Value != cover)
                        {
                            book.Images.Add(new Image
                            {
                                Book = book,
                                Path = $"{bookId}/{bin.Attributes["id"].Value}"
                            });
                        }
                        else
                        {
                            book.TitleInfo.Cover = $"{bookId}/{bin.Attributes["id"].Value}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }

            return book;
        }
    }
}