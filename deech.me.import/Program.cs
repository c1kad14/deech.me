using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using deech.me.import.utils;


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
            var totalCount = files.Count;

            builder.UseSqlServer("Server=127.0.0.1,1433;Database=DeechMeDb;User Id=SA;Password=1Secure*Password1");

            foreach (var file in files)
            {
                Console.Clear();
                Console.WriteLine($"*** {--totalCount} of {files.Count} books to import ***");

                var book = parser.Parse(file);

                if (book != null)
                {
                    await importProcessor.Process(book);
                }
            }

            Console.WriteLine("*** Done ***");
        }
    }
}