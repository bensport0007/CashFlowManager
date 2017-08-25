using Microsoft.Practices.Unity;

namespace CashFlowManager.IOC
{
    public class Bootstrapper
    {
        private readonly IUnityContainer _container;

        public Bootstrapper(IUnityContainer container)
        {
            _container = container;
        }

        public void ConfigureIoC()
        {
            _container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);

            FluentNHibernateSQLiteCSharp.IOC.Bootstrapper.ConfigureIoC(_container);

            //_container.RegisterType<IDonatorsViewer, DonatorsViewer>();
            //_container.RegisterType<IDonatorService, DonatorService>();
            //_container.RegisterType<ISearchFilter<Donator>, SearchFilter<Donator>>();
            //_container.RegisterType<IQueryHelper<Donator>, QueryHelper<Donator>>();


            //_container.RegisterType<ITransactionsViewer, TransactionsViewer>();
            //_container.RegisterType<ITransactionService, TransactionService>();
            //_container.RegisterType<ISearchFilter<Transaction>, SearchFilter<Transaction>>();
            //_container.RegisterType<IQueryHelper<Transaction>, QueryHelper<Transaction>>();
        }
    }
}