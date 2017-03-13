using FluentNHibernateSQLiteCSharp;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Services;
using FluentNHibernateSQLiteCSharp.Session;
using Microsoft.Practices.Unity;

namespace CashFlowManager.IOC
{
    public class Bootstrapper
    {
        public void ConfigureIoC()
        {
            var container = DependencyFactory.Container;
            FluentNHibernateSQLiteCSharp.IOC.Bootstrapper.ConfigureIoC(container);

            container.RegisterType<IDonatorService, DonatorService>();
            container.RegisterInstance<IQueryHelper<Donator>>(new QueryHelper<Donator>());
            container.RegisterType<IQueryHelper<Donator>, QueryHelper<Donator>>();
        }
    }
}