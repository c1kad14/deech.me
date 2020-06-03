namespace deech.me.logic.models
{
    public class CommentModel
    {
        public int? AssociatedId { get; set; }
        public string Created { get; set; }
        public int Id { get; set; }
        public int ParagraphId { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Value { get; set; }
    }
}