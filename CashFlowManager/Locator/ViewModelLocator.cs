using CashFlowManager.Donators;
using CashFlowManager.IOC;
using CashFlowManager.Posts;
using CashFlowManager.Transactions;

namespace CashFlowManager.Locator
{
    public class ViewModelLocator
    {
        public DonatorsViewerViewModel DonatorsViewerViewModel => DependencyFactory.Resolve<DonatorsViewerViewModel>();

        public TransactionsViewerViewModel TransactionsViewerViewModel => DependencyFactory.Resolve<TransactionsViewerViewModel>();

        public PostsViewerViewModel PostsViewerViewModel => DependencyFactory.Resolve<PostsViewerViewModel>();
    }
}