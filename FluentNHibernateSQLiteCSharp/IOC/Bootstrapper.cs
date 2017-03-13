using CashFlowManagerDomain.IOC;
using Microsoft.Practices.Unity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentNHibernateSQLiteCSharp.IOC
{
    public static class Bootstrapper
    {
        public static void ConfigureIoC(IUnityContainer container)
        {
            ContainerAccessor.ConfigureContainer(container);
            container.RegisterInstance<ISession>(SessionManager.GetInstance());
        }
    }
}
