namespace deech.me.logic.models
{
    public class CitationModel
    {
        public int Id { get; set; }
        public string Created { get; set; }
        public int ParagraphId  { get; set; }
        public string UserBookId { get; set; }
        public string Value { get; set; }
    }
}