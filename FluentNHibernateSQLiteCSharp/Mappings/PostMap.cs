using FluentNHibernate.Mapping;
using FluentNHibernateSQLiteCSharp.Entities;

namespace FluentNHibernateSQLiteCSharp.Mappings
{
    public class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Id(x => x.Id);
            Map(x => x.Number);
            Map(x => x.Type);
            Map(x => x.UntilDate);
            Map(x => x.Description);
        }
    }
}