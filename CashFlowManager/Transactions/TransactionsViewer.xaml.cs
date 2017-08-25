namespace CashFlowManager.Transactions
{
    /// <summary>
    ///     Logique d'interaction pour TransactionsViewer.xaml
    /// </summary>
    public partial class TransactionsViewer : ITransactionsViewer
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