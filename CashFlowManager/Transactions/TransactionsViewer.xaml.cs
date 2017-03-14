using System.Windows;

namespace CashFlowManager.Transactions
{
    /// <summary>
    ///     Interaction logic for TransactionsViewer.xaml
    /// </summary>
    public partial class TransactionsViewer : Window, ITransactionForm
    {
        public TransactionsViewer()
        {
            InitializeComponent();
        }

        public new void ShowDialog()
        {
            base.ShowDialog();
        }
    }
}