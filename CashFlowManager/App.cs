using FluentNHibernateSQLiteCSharp; // Application, StartupEventArgs, WindowState
using System.Windows;
using CashFlowManager.IOC;

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
            var bootstrapper = new Bootstrapper();
            bootstrapper.ConfigureIoC();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void StartViaProgram()
        {
            Program.Main(); 
        }
    }
}