using FluentNHibernate.Mapping;
using FluentNHibernateSQLiteCSharp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentNHibernateSQLiteCSharp.Mappings
{
    public class TransactionMap : ClassMap<Transaction>
    {
        public TransactionMap()
        {
            Id(x => x.Id);
            References(x => x.donator);
            Map(x => x.amount);
            Map(x => x.date);
            Map(x => x.depositMethod);
            References(x => x.post);
        }
    }
}
