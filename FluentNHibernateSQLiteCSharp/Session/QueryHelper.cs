using System;
using System.Collections.Generic;
using System.Linq;
using CashFlowManagerDomain.IOC;
using FluentNHibernateSQLiteCSharp.Entities;
using NHibernate;

namespace FluentNHibernateSQLiteCSharp.Session
{
    public class QueryHelper<TConcreteType> : IQueryHelper<TConcreteType> where TConcreteType : BaseEntity
    {
        private readonly ISession _session;

        public QueryHelper() : this(ContainerAccessor.Resolve<ISession>())
        {
        }

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