using System.Collections.Generic;
using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class UserBook : IWriteEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Created { get; set; }
        public int Progress { get; set; }
        public string Updated { get; set; }
        public string UserId { get; set; }
        public bool Favourite { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
        public List<Citation> Citations { get; set; }
        public List<Note> Notes { get; set; }
    }
}