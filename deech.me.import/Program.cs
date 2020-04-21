using System;

namespace deech.me.import
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = BookReader.GetBooks();

            books.ForEach(b => System.Console.WriteLine(BookReader.GetBookContent(b)));
        }
    }
}
