using System.Windows;
using CashFlowManager.Donators;
using CashFlowManager.Transactions;

namespace CashFlowManager
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDonatorForm _donatorForm;
        private readonly ITransactionForm _transactionForm;

        public MainWindow(IDonatorForm donatorForm, ITransactionForm transactionForm) //TODO:Use navigation service ?
        {
            _donatorForm = donatorForm;
            _transactionForm = transactionForm;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _donatorForm.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _transactionForm.ShowDialog();
        }
    }
}