using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class TitleInfo : IReadEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public Annotation Annotation { get; set; }
        public List<TitleInfoAuthor> Authors { get; set; } = new List<TitleInfoAuthor>();
        public string Cover { get; set; }
        public string Date { get; set; }
        public List<TitleInfoGenre> Genres { get; set; } = new List<TitleInfoGenre>();
        public List<TitleInfoKeyword> Keywords { get; set; } = new List<TitleInfoKeyword>();
        public Language Language { get; set; }
        public Language SourceLanguage { get; set; }
        public string Title { get; set; }
        public List<TitleInfoTranslator> Translators { get; set; } = new List<TitleInfoTranslator>();
    }
}