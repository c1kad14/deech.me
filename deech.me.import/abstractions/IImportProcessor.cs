using System.Threading.Tasks;
using deech.me.data.entities;

namespace deech.me.import.abstractions
{
    public interface IImportProcessor
    {
        Task Process(Book book);
    }
}