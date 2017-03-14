using System.Collections.Generic;
using NHibernate;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public class DataPersistenceService : ICanPersistData
    {
        private readonly ISession _session;

        public DataPersistenceService(ISession session)
        {
            _session = session;
        }

        public void PersistObject(object objectToPersist)
        {
            var transaction = _session.BeginTransaction();
            _session.SaveOrUpdate(objectToPersist);
            transaction.Commit();
        }

        public void PersistObjectsList(IEnumerable<object> objectsToPersist)
        {
            var transaction = _session.BeginTransaction();
            foreach (var item in objectsToPersist)
                _session.SaveOrUpdate(item);

            transaction.Commit();
        }
    }
}