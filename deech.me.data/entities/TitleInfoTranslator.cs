namespace deech.me.data.entities
{
    public class TitleInfoTranslator
    {
        public int Id { get; set; }
        public int TitleInfoId { get; set; }
        public TitleInfo TitleInfo { get; set; }
        public int TranslatorId { get; set; }
        public Person Translator { get; set; }
    }
}