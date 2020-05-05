using System.Collections.Generic;
using System.IO;
using System.Linq;

using deech.me.import.models;

namespace deech.me.import.utils
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