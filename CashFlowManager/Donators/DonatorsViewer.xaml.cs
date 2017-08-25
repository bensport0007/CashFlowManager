using System.Windows;

namespace CashFlowManager.Donators
{
    /// <summary>
    ///     Interaction logic for DonatorsViewer.xaml
    /// </summary>
    public partial class DonatorsViewer : Window, IDonatorsViewer
    {
        public DonatorsViewer()
        {
            InitializeComponent();
        }

        public new void ShowDialog()
        {
            base.ShowDialog();
        }
    }
}