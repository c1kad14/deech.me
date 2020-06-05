using System.Collections.Generic;

using deech.me.logic.abstractions;

namespace deech.me.logic.models
{
    public class TitleInfoModel : IModel
    {
        public int Id { get; set; }
        public string Annotation { get; set; }
        public List<string> Authors { get; set; }
        public string Cover { get; set; }
        public string Date { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Keywords { get; set; }
        public string Language { get; set; }
        public string SourceLanguage { get; set; }
        public string Title { get; set; }
        public List<string> Translators { get; set; }
    }
}