using System.Windows;
using CashFlowManager.Donators;
using CashFlowManager.IOC;
using Microsoft.Practices.Unity;

namespace CashFlowManager
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var donatorForms = DependencyFactory.Container.Resolve<DonatorsViewer>();
            donatorForms.ShowDialog();
        }
    }
}