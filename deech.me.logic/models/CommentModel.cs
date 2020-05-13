using System;

namespace deech.me.logic.models
{
    public class CommentModel
    {
        public int? AssociatedId { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public int ParagraphId { get; set; }
        public string Value { get; set; }
    }
}