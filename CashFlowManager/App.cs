using FluentNHibernateSQLiteCSharp;
using System.Windows;
using CashFlowManager.IOC;
using Microsoft.Practices.Unity;

namespace CashFlowManager
{
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            StartViaBootStrapper();
            //StartViaProgram();
        }

        private void StartViaBootStrapper()
        {
            var container = DependencyFactory.Container;
            var bootstrapper = new Bootstrapper(container);
            bootstrapper.ConfigureIoC();

            var mainWindow = container.Resolve<MainWindow>();

            //MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void StartViaProgram()
        {
            Program.Main(); 
        }
    }
}