using FluentNHibernateSQLiteCSharp.Entities.Interfaces;

namespace FluentNHibernateSQLiteCSharp.Entities
{
    public class Post : BaseEntity, IPost
    {
        public virtual int Id { get; set; }
        public virtual int Number { get; set; }
        public virtual string Description { get; set; }
    }
}