using System;
using System.Collections.Generic;

namespace FluentNHibernateSQLiteCSharp.Entities.Interfaces
{
    public interface IProduct : IBaseEntity
    {
        int Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        IList<Store> StoresStockedIn { get; set; }
    }
}
