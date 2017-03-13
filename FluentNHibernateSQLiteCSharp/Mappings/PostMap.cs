using FluentNHibernate.Mapping;
using FluentNHibernateSQLiteCSharp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
