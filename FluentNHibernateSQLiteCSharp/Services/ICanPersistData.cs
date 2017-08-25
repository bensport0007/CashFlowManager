using System.Collections.Generic;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public interface ICanPersistData
    {
        void PersistObject(object objectToPersist);
        void PersistObjectsList(IEnumerable<object> objectsToPersist);
    }
}