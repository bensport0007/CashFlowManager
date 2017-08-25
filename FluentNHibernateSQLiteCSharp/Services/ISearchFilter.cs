using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public class SearchFilter<T> : ISearchFilter<T>
    {
        private const string FilterWildcard = "*";

        public IEnumerable<T> Filter(string property, string value, IEnumerable<T> listToFilter)
        {
            if (property == string.Empty || value == string.Empty)
                return listToFilter;

            var pinfo = typeof(T).GetProperty(property);

            if (value.Contains(FilterWildcard))
            {
                var valueWithoutWildCard = value.Replace(FilterWildcard, string.Empty);
                if (value.StartsWith(FilterWildcard))
                    return listToFilter.Where(x => pinfo.GetValue(x, null).ToString().EndsWith(valueWithoutWildCard)).ToList();

                if (value.EndsWith(FilterWildcard))
                    return listToFilter.Where(x => pinfo.GetValue(x, null).ToString().StartsWith(valueWithoutWildCard)).ToList();
            }

            return listToFilter.Where(x => pinfo.GetValue(x, null).ToString() == value).ToList();
        }
    }
}