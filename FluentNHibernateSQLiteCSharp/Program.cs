using FluentNHibernateSQLiteCSharp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;
using NHibernate;
using System.IO;
using FluentNHibernate.Cfg;
using Microsoft.Practices.Unity;
using FluentNHibernateSQLiteCSharp.IOC;
using FluentNHibernateSQLiteCSharp.Entities.Interfaces;
using Interfaces = FluentNHibernateSQLiteCSharp.Entities.Interfaces;
using FluentNHibernateSQLiteCSharp.Session;
using CashFlowManagerDomain.IOC;

namespace FluentNHibernateSQLiteCSharp
{
    public class Program
    {
        public static void Main()
        {
            ContainerAccessor.Container().RegisterInstance<ISession>(SessionManager.GetInstance());
            ContainerAccessor.Container().RegisterInstance<IQueryHelper<Employee>>(new QueryHelper<Employee>());
            ContainerAccessor.Container().RegisterInstance<IQueryHelper<Transaction>>(new QueryHelper<Transaction>());
            ContainerAccessor.Container().RegisterInstance<IQueryHelper<Donator>>(new QueryHelper<Donator>());
            
            var application = new App();
            application.Start();

        }
    }
}
