using System.Collections.Generic;
using FluentNHibernateSQLiteCSharp.Entities;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public interface ITransactionService
    {
        IList<Transaction> GetAllTransactions();
        IList<Transaction> GetAllTransactionsInGivenYear(int year);
        IList<Transaction> GetAllTransactionsInGivenYearAndMonth(int year, int month);
        IList<Transaction> GetAllTransactionsFromDonatorById(int donatorId);
        IList<Transaction> GetAllTransactionsInYearFromDonatorByNumber(int donatorNumber, int year);
    }
}