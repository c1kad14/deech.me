using System;

namespace deech.me.logic.models
{
    public class CommentModel
    {
        public int? AssociatedId { get; set; }
        public string Created { get; set; }
        public int Id { get; set; }
        public int ParagraphId { get; set; }
        public string UserInfoId { get; set; }
        public string Value { get; set; }
    }
}