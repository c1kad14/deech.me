using System.Collections.Generic;

using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class BookCollection : IWriteEntity
    {
        public int Id { get; set; }
        public string Created { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public List<TitleInfo> TitleInfos { get; set; }
        public string Updated { get; set; }
        public string UserId { get; set; }
    }
}