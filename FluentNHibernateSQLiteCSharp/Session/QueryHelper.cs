using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Entities.Interfaces;
using FluentNHibernateSQLiteCSharp.IOC;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernateSQLiteCSharp.Session;
using CashFlowManagerDomain.IOC;

namespace FluentNHibernateSQLiteCSharp
{
    public class QueryHelper<TConcreteType> : IQueryHelper<TConcreteType> where TConcreteType : BaseEntity
    {
        private ISession _session;

        public QueryHelper() : this(ContainerAccessor.Resolve<ISession>()) { }

        public QueryHelper(ISession session)
        {
            _session = session;
        }

        public IList<TConcreteType> GetAllThatFitExpression(Func<TConcreteType, bool> seachCriteria)
        {
            return _session.CreateCriteria<TConcreteType>().List<TConcreteType>().Where(seachCriteria).ToList();
        }

        public IList<TConcreteType> GetAll()
        {
            return _session.CreateCriteria<TConcreteType>().List<TConcreteType>().ToList();
        }
    }
}
