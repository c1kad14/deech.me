using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace deech.me.data.entities
{
    public class UserInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
        public List<FavouriteBook> Books { get; set; }
        public List<BookCollection> Collections { get; set; }
        public List<Citation> Citations { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Note> Notes { get; set; }
        public string Username { get; set; }
    }
}