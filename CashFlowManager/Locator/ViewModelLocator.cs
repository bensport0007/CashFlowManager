using CashFlowManager.Donators;
using CashFlowManager.IOC;
using CashFlowManager.Transactions;

namespace CashFlowManager.Locator
{
    public class ViewModelLocator
    {
        public DonatorViewModel DonatorViewModel
        {
            get { return DependencyFactory.Resolve<DonatorViewModel>(); }
        }

        public TransactionViewModel TransactionViewModel
        {
            get { return DependencyFactory.Resolve<TransactionViewModel>(); }
        }
    }
}