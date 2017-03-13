using FluentNHibernate.Mapping;
using FluentNHibernateSQLiteCSharp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentNHibernateSQLiteCSharp.Mappings
{
    public class DonatorMap : ClassMap<Entities.Donator>
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
