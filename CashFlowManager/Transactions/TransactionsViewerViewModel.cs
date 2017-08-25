using CashFlowManager.Properties;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Services;

namespace CashFlowManager.Transactions
{
    public class TransactionsViewerViewModel : ViewerViewModelBase<Transaction>
    {
        public TransactionsViewerViewModel(ICanPersistData dataPersistenceService,
            ISearchFilter<Transaction> searchfilter,
            ITransactionService transactionService, IValidationService validationService)
            : base(dataPersistenceService, searchfilter, validationService)
        {
            ItemsList = transactionService.GetAllTransactions();
        }

        public override string Title
        {
            get { return Resources.TransactionViewModel_Title_Transaction; }
        }
    }
}