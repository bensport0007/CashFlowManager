using System.Windows;
using CashFlowManager.Donators;
using CashFlowManager.Posts;
using CashFlowManager.Transactions;

namespace CashFlowManager
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDonatorsViewer _donatorsViewer;
        private readonly ITransactionsViewer _transactionsViewer;
        private readonly IPostsViewer _postsViewer;

        public MainWindow(IDonatorsViewer donatorsViewer,
            ITransactionsViewer transactionsViewer,
            IPostsViewer postsViewer) //TODO:Use navigation service ?
        {
            _donatorsViewer = donatorsViewer;
            _transactionsViewer = transactionsViewer;
            _postsViewer = postsViewer;
            InitializeComponent();
        }

        private void Donators_Click(object sender, RoutedEventArgs e)
        {
            _donatorsViewer.ShowDialog();
        }

        private void Transactions_Click(object sender, RoutedEventArgs e)
        {
            _transactionsViewer.ShowDialog();
        }

        private void Posts_Click(object sender, RoutedEventArgs e)
        {
            _postsViewer.ShowDialog();
        }
    }
}