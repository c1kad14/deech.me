namespace deech.me.data.entities
{
    public class FavouriteBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Created { get; set; }
        public string UserId { get; set; }
    }
}