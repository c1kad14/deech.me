using System;
using System.Collections.Generic;
using System.Text;
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

            using (var context = new DeechMeDataContext(builder.Options))
            {
                context.AddRange(books);
                context.SaveChanges();
            }
        }
    }
}
