using FluentNHibernate.Mapping;
using FluentNHibernateSQLiteCSharp.Entities;

namespace FluentNHibernateSQLiteCSharp.Mappings
{
    public class DonatorMap : ClassMap<Donator>
    {
        public DonatorMap()
        {
            Id(x => x.Id);
            Map(x => x.Number).Unique();
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}