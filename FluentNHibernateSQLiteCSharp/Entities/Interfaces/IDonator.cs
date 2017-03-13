using FluentNHibernateSQLiteCSharp.Entities.Interfaces;
using System;

namespace FluentNHibernateSQLiteCSharp.Entities.Interfaces
{
    public interface IDonator
    {
        int Id { get; }
        int Number { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
