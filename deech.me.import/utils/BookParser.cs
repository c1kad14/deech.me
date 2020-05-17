using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

using deech.me.data.entities;
using deech.me.import.abstractions;
using deech.me.import.models;
using ImageMagick;

namespace deech.me.import.utils
{
    public class BookParser : IBookParser
    {
        private int _sequence;
        private Book _book;
        private XmlDocument _doc;

        public Book Parse(FileInfo file)
        {
            this._sequence = 0;

            this._book = new Book();
            try
            {
                this._doc = new XmlDocument();
                this._doc.Load(file.FullName);

                var bk = new XmlNamespaceManager(this._doc.NameTable);
                bk.AddNamespace("bk", "http://www.gribuser.ru/xml/fictionbook/2.0");

                var root = this._doc.DocumentElement;
                var cover = root.SelectSingleNode("//bk:description/bk:title-info/bk:coverpage/bk:image", bk)?.Attributes[0]?.Value?.Replace("#", "");
                var genres = root.SelectNodes("//bk:description/bk:title-info/bk:genre", bk);
                var authors = root.SelectNodes("//bk:description/bk:title-info/bk:author", bk);
                var translators = root.SelectNodes("//bk:description/bk:title-info/bk:translator", bk);
                var bodies = root.SelectNodes("//bk:body", bk);
                var binary = root.SelectNodes("//bk:binary", bk);
                this._book.Id = int.Parse(file.Name.Remove(file.Name.IndexOf(".fb2"), 4));
                var directory = $"{Configuration.Instance.ProcessedFolder}/{this._book.Id}";


                this._book.TitleInfo = new TitleInfo
                {
                    Id = this._book.Id,
                    Title = root.SelectSingleNode("//bk:description/bk:title-info/bk:book-title", bk)?.InnerText,
                    Date = root.SelectSingleNode("//bk:description/bk:title-info/bk:date", bk)?.InnerText,
                };

                if (!string.IsNullOrEmpty(root.SelectSingleNode("//bk:description/bk:title-info/bk:annotation", bk)?.InnerText))
                {
                    this._book.TitleInfo.Annotation = new Annotation { Text = root.SelectSingleNode("//bk:description/bk:title-info/bk:annotation", bk)?.InnerText };
                }

                foreach (XmlNode genre in genres)
                {
                    if (!this._book.TitleInfo.Genres.Exists(g => g.Genre.Code == genre.InnerText))
                    {
                        this._book.TitleInfo.Genres.Add(new TitleInfoGenre { TitleInfo = this._book.TitleInfo, Genre = new Genre { Code = genre.InnerText } });
                    }
                }

                if (root.SelectSingleNode("//bk:description/bk:title-info/bk:keywords", bk)?.InnerText != null)
                {
                    var keywords = root.SelectSingleNode("//bk:description/bk:title-info/bk:keywords", bk).InnerText.Split(",");

                    foreach (var keyword in keywords)
                    {
                        if (!this._book.TitleInfo.Keywords.Exists(k => k.Keyword.Code == keyword.Trim()))
                        {
                            this._book.TitleInfo.Keywords.Add(new TitleInfoKeyword { TitleInfo = this._book.TitleInfo, Keyword = new Keyword { Code = keyword.Trim() } });
                        }
                    }
                }

                foreach (XmlNode author in authors)
                {
                    this._book.TitleInfo.Authors.Add(new TitleInfoAuthor
                    {
                        TitleInfo = this._book.TitleInfo,
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
                    this._book.TitleInfo.Translators.Add(new TitleInfoTranslator
                    {
                        TitleInfo = this._book.TitleInfo,
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
                    this._book.TitleInfo.Language = new Language { Code = root.SelectSingleNode("//bk:description/bk:title-info/bk:lang", bk).InnerText };
                }

                if (root.SelectSingleNode("//bk:description/bk:title-info/bk:source-lang", bk)?.InnerText != null)
                {
                    this._book.TitleInfo.SourceLanguage = new Language { Code = root.SelectSingleNode("//bk:description/bk:title-info/bk:source-language", bk).InnerText };
                }

                if (!string.IsNullOrEmpty(root.SelectSingleNode("//bk:description/bk:publish-info", bk)?.InnerText))
                {
                    this._book.PublishInfo = new PublishInfo
                    {
                        Id = this._book.Id,
                        City = root.SelectSingleNode("//bk:description/bk:publish-info/bk:city", bk)?.InnerText,
                        Publisher = root.SelectSingleNode("//bk:description/bk:publish-info/bk:publisher", bk)?.InnerText,
                        Year = root.SelectSingleNode("//bk:description/bk:publish-info/bk:year", bk)?.InnerText,
                        BookName = root.SelectSingleNode("//bk:description/bk:publish-info/bk:book-name", bk)?.InnerText
                    };
                }

                if (!string.IsNullOrEmpty(root.SelectSingleNode("//bk:description/bk:custom-info", bk)?.InnerText))
                {
                    this._book.CustomInfo = new CustomInfo
                    {
                        Id = this._book.Id,
                        Text = root.SelectSingleNode("//bk:description/bk:custom-info", bk)?.InnerText
                    };
                }
                var paragraphs = new List<Paragraph>();

                foreach (XmlNode body in bodies)
                {
                    ParseNode(body, paragraphs);
                }

                this._book.Paragraphs = paragraphs;

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

                        var imgBytes = Convert.FromBase64String(bin.InnerXml);
                        TransformImageAndWrite(imgBytes, filePath);

                        if (bin.Attributes["id"].Value == cover)
                        {
                            this._book.TitleInfo.Cover = $"{this._book.Id}/{bin.Attributes["id"].Value}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }

            return this._book;
        }

        public void ParseNode(XmlNode node, List<Paragraph> paragraphs)
        {
            switch (node.Name)
            {
                case "p":
                case "title":
                case "epigraph":
                case "cite":
                case "poem":
                case "code":
                case "subtitle":
                case "table":
                    var newNode = this._doc.CreateNode(node.NodeType, node.Name, string.Empty);

                    if (node.HasChildNodes)
                    {
                        ParseChildNodesForParagraph(node, newNode);
                    }
                    else
                    {
                        newNode = node;
                    }

                    paragraphs.Add(new Paragraph { Book = this._book, Sequence = ++this._sequence, Type = node.Name, Value = newNode.InnerXml });
                    break;
                case "image":
                    foreach (XmlAttribute attribute in node.Attributes)
                    {
                        if (attribute.Name.Contains("href") && !string.IsNullOrEmpty(attribute.Value))
                        {
                            paragraphs.Add(new Paragraph { Book = this._book, Sequence = ++this._sequence, Type = node.Name, Value = $"{this._book.Id}/{attribute.Value.Replace("#", "")}" });
                        }
                    }
                    break;
                case "section":
                    if (node.Attributes["id"] != null && !string.IsNullOrEmpty(node.Attributes["id"].Value))
                    {
                        //anchor to current note
                        var refChild = this._doc.CreateElement("a");
                        var refAttributeId = this._doc.CreateAttribute("id");
                        refAttributeId.Value = node.Attributes["id"].Value;
                        refChild.Attributes.Append(refAttributeId);
                        refChild.InnerText = string.Empty;
                        node.PrependChild(refChild);

                        var refBackElement = this._doc.CreateElement("a");
                        var refBackAttribute = this._doc.CreateAttribute("href");

                        refBackAttribute.Value = $"book/{this._book.Id}#ref{node.Attributes["id"].Value}";
                        refBackElement.InnerText = "^^^";
                        refBackElement.Attributes.Append(refBackAttribute);

                        node.AppendChild(refBackElement);

                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name == "title")
                            {
                                var newChild = this._doc.CreateElement("h3");
                                newChild.InnerXml = child.InnerXml;
                                node.ReplaceChild(newChild, child);
                            }
                        }

                        paragraphs.Add(new Paragraph { Book = this._book, Sequence = ++this._sequence, Type = "p", Value = node.InnerXml });
                    }
                    else
                    {
                        ParseChildNodes(node, paragraphs);
                    }
                    break;
                default:
                    ParseChildNodes(node, paragraphs);
                    break;
            }
        }

        public void ParseChildNodes(XmlNode node, List<Paragraph> paragraphs)
        {
            if (node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    ParseNode(child, paragraphs);
                }
            }
        }

        public void ParseChildNodesForParagraph(XmlNode node, XmlNode newNode)
        {
            for (var i = 0; i < node.ChildNodes.Count; i++)
            {
                if (node.ChildNodes[i].Name == "image")
                {
                    var newChild = this._doc.CreateElement("img");
                    var newAttribute = this._doc.CreateAttribute("src");

                    for (var j = 0; j < node.ChildNodes[i].Attributes.Count; j++)
                    {
                        if (node.ChildNodes[i].Attributes[j].Name.Contains("href") && !string.IsNullOrEmpty(node.ChildNodes[i].Attributes[j].Value))
                        {
                            newAttribute.Value = $"{this._book.Id}/{node.ChildNodes[i].Attributes[j].Value.Replace("#", "")}";
                            newChild.Attributes.Append(newAttribute);
                        }
                    }
                    newNode.AppendChild(newChild);
                }
                else if (node.ChildNodes[i].Name == "a")
                {
                    var newChild = this._doc.CreateElement("a");
                    var newAttribute = this._doc.CreateAttribute("href");

                    newChild.InnerText = node.ChildNodes[i].InnerText;

                    for (var j = 0; j < node.ChildNodes[i].Attributes.Count; j++)
                    {
                        if (node.ChildNodes[i].Attributes[j].Name.Contains("href") && !string.IsNullOrEmpty(node.ChildNodes[i].Attributes[j].Value))
                        {
                            if (node.ChildNodes[i].Attributes["type"]?.Value == "note")
                            {
                                //anchor tp current paragaph
                                var refChild = this._doc.CreateElement("a");
                                refChild.InnerText = string.Empty;
                                var refAttributeId = this._doc.CreateAttribute("id");

                                refAttributeId.Value = $"ref{node.ChildNodes[i].Attributes[j].Value.Replace("#", "")}";
                                refChild.Attributes.Append(refAttributeId);
                                newNode.AppendChild(refChild);

                                //link to note
                                newAttribute.Value = $"book/{this._book.Id}{node.ChildNodes[i].Attributes[j].Value}";
                                newChild.Attributes.Append(newAttribute);

                                var wrapper = this._doc.CreateElement("sup");
                                wrapper.AppendChild(newChild);
                                newNode.AppendChild(wrapper);
                            }
                            else
                            {
                                newAttribute.Value = node.ChildNodes[i].Attributes[j].Value;
                                newChild.Attributes.Append(newAttribute);
                                newNode.AppendChild(newChild);
                            }
                        }
                    }
                }
                else
                {
                    if (node.ChildNodes[i].HasChildNodes)
                    {
                        var newChildNode = this._doc.CreateNode(node.ChildNodes[i].NodeType, node.ChildNodes[i].Name, string.Empty);
                        ParseChildNodesForParagraph(node.ChildNodes[i].Clone(), newChildNode);
                        newNode.AppendChild(newChildNode);
                    }
                    else
                    {
                        newNode.AppendChild(node.ChildNodes[i].Clone());
                    }
                }
            }
        }

        private void TransformImageAndWrite(byte[] imgBytes, string filePath)
        {
            var size = 300;
            int width = 0, height = 0;

            using var image = new MagickImage(imgBytes);

            if (image.Width > image.Height)
            {
                width = size;
                height = Convert.ToInt32(image.Height * size / (double)image.Width);
            }
            else
            {
                height = size;
                width = Convert.ToInt32(image.Width * size / (double)image.Height);
            }

            image.Resize(width, height);
            image.Write(filePath);
        }
    }
}