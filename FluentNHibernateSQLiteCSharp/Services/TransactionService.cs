using System.Collections.Generic;
using System.Linq;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Session;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IQueryHelper<Transaction> _transactionQuerier;

        public TransactionService(IQueryHelper<Transaction> transactionQuerier)
        {
            _transactionQuerier = transactionQuerier;
        }

        public IList<Transaction> GetAllTransactions()
        {
            return _transactionQuerier.GetAll();
        }

        public IList<Transaction> GetAllTransactionsInGivenYear(int year)
        {
            return _transactionQuerier.GetAllThatFitExpression(x => x.date.Year == year);
        }

        public IList<Transaction> GetAllTransactionsInGivenYearAndMonth(int year, int month)
        {
            return _transactionQuerier.GetAllThatFitExpression(x => x.date.Year == year && x.date.Month == month);
        }

        public IList<Transaction> GetAllTransactionsFromDonatorById(int donatorId)
        {
            return _transactionQuerier.GetAllThatFitExpression(x => x.donator.Id == donatorId);
        }

        public IList<Transaction> GetAllTransactionsInYearFromDonatorByNumber(int donatorNumber, int year)
        {
            return GetAllTransactionsInGivenYear(year).Where(x => x.donator.Number == donatorNumber).ToList();
        }
    }
}