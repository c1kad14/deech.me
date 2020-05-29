using System.Collections.Generic;

namespace deech.me.data.entities
{
    public class BookCollection
    {
        public int Id { get; set; }
        public string Created { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public List<TitleInfo> TitleInfos { get; set; }
        public string Updated { get; set; }
        public string UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}