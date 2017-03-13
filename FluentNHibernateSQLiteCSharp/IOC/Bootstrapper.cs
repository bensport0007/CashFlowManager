using CashFlowManagerDomain.IOC;
using FluentNHibernateSQLiteCSharp.Services;
using FluentNHibernateSQLiteCSharp.Session;
using Microsoft.Practices.Unity;
using NHibernate;

namespace FluentNHibernateSQLiteCSharp.IOC
{
    public static class Bootstrapper
    {
        public static void ConfigureIoC(IUnityContainer container)
        {
            ContainerAccessor.ConfigureContainer(container);
            container.RegisterInstance(SessionManager.GetInstance());
            container.RegisterInstance<IDataPersistenceService>(new DataPersistenceService(container.Resolve<ISession>()));
        }
    }
}