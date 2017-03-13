using System;

namespace FluentNHibernateSQLiteCSharp.Entities.Interfaces
{
    interface IPost
    {
        string Description { get; }
        int Id { get; }
        int Number { get; }
    }
}
