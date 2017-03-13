using CashFlowManagerDomain.IOC;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Session;
using Microsoft.Practices.Unity;

namespace FluentNHibernateSQLiteCSharp
{
    public class Program
    {
        public static void Main()
        {
            ContainerAccessor.Container().RegisterInstance(SessionManager.GetInstance());
            ContainerAccessor.Container().RegisterInstance<IQueryHelper<Transaction>>(new QueryHelper<Transaction>());
            ContainerAccessor.Container().RegisterInstance<IQueryHelper<Donator>>(new QueryHelper<Donator>());

            var application = new App();
            application.Start();
        }
    }
}