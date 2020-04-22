using System.IO;
using deech.me.data.entities;

namespace deech.me.import.abstractions
{
    public interface IParser
    {
         Book Parse(FileInfo file);
    }
}