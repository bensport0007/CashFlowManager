using System.Collections.Generic;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public interface IDataPersistenceService
    {
        void PersistData(object objectToPersist);
        void PersistData(IEnumerable<object> objectsToPersist);
    }
}