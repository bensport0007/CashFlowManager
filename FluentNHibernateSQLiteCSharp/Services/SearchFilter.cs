using System.Collections.Generic;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public interface ISearchFilter<T>
    {
        IEnumerable<T> Filter(string property, string value, IEnumerable<T> listToFilter);
    }
}