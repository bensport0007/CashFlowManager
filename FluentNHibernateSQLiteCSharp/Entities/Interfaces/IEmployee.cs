using System;

namespace FluentNHibernateSQLiteCSharp.Entities.Interfaces
{
    public interface IEmployee : IBaseEntity
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Store Store { get; set; }
    }
}
