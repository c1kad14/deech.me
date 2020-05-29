namespace deech.me.data.entities
{
    public class FavouriteBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Date { get; set; }
        public string UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}