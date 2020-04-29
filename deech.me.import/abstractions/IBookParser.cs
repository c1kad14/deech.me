using System.IO;
using deech.me.data.entities;

namespace deech.me.import.abstractions
{
    public interface IBookParser
    {
         Book Parse(FileInfo file);
    }
}