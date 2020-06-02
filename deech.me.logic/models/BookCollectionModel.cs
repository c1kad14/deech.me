using System.Collections.Generic;

namespace deech.me.logic.models
{
    public class BookCollectionModel
    {
        public int Id { get; set; }
        public string Created { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public List<TitleInfoModel> TitleInfos { get; set; }
        public string Updated { get; set; }
        public string UserId { get; set; }
    }
}