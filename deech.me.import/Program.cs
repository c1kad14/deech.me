using System;
using System.Threading.Tasks;
using deech.me.import.utils;
using Microsoft.EntityFrameworkCore;

namespace deech.me.import
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var files = BookReader.GetBooks();
            var builder = new DbContextOptionsBuilder();
            var importProcessor = new ImportProcessor(builder.Options);
            var parser = new BookParser();

            builder.UseSqlServer("Server=127.0.0.1,1433;Database=DeechMeDb;User Id=SA;Password=1Secure*Password1");

            foreach (var file in files)
            {
                var book = parser.Parse(file);

                if (book != null)
                {
                    await importProcessor.Process(book);
                }
            }

            Console.WriteLine($"EXCEPTION COUNT {BookParser.ExceptionCount}");
        }
    }
}