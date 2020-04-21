using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace deech.me.import
{
    public class BookReader
    {
        public static List<FileInfo> GetBooks()
        {
            var directory = new DirectoryInfo(Configuration.Instance.ImportFolder);

            return directory.GetFiles("*.fb2", SearchOption.AllDirectories).ToList();
        }

        public static string GetBookContent(FileInfo file)
        {
            using var stream = file.OpenText();
            return stream.ReadToEnd();
        }
    }
}