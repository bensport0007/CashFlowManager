using System.Collections.Generic;
using NHibernate;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public class PersistenceService
    {
        private readonly ISession _session;

        public PersistenceService(ISession session)
        {
            _session = session;
        }

        public void PersistData(object objectToPersist)
        {
            //var transaction = _session.BeginTransaction();
            _session.SaveOrUpdate(objectToPersist);
            //transaction.Commit();
        }

        public void PersistData(IList<object> objectsToPersist)
        {
            //var transaction = _session.BeginTransaction();
            foreach (var item in objectsToPersist)
                _session.SaveOrUpdate(item);

            //transaction.Commit();
        }
    }
}