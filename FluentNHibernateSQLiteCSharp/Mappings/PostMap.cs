using FluentNHibernate.Mapping;
using FluentNHibernateSQLiteCSharp.Entities;

namespace FluentNHibernateSQLiteCSharp.Mappings
{
    public class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Id(x => x.Id);
            Map(x => x.Number).Unique();
            Map(x => x.Description);
        }
    }
}