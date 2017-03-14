using CashFlowManager.Properties;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Services;

namespace CashFlowManager.Transactions
{
    public class TransactionViewModel : ViewerViewModelBase<Transaction>
    {
        public TransactionViewModel(ICanPersistData dataPersistenceService,
            ISearchFilter<Transaction> searchfilter,
            ITransactionService transactionService)
            : base(dataPersistenceService, searchfilter)
        {
            ItemsList = transactionService.GetAllTransactions();
        }

        public override string Title
        {
            get { return Resources.TransactionViewModel_Title_Transaction; }
        }
    }
}