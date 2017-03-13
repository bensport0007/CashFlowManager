using System;
using FluentNHibernateSQLiteCSharp.Entities.Interfaces;

namespace FluentNHibernateSQLiteCSharp.Entities.Interfaces
{
    public interface ITransaction : IBaseEntity
    {
        double amount { get; set; }
        DateTime date { get; set; }
        DepositMethod depositMethod { get; set; }
        Donator donator { get; set; }
        int Id { get; }
        Post post { get; set; }
        TransactionType type { get; set; }
    }
}
