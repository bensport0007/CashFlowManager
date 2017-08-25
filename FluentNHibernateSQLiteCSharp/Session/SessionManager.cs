using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernateSQLiteCSharp.Entities.Interfaces;
using FluentNHibernateSQLiteCSharp.IOC;
using Microsoft.Practices.Unity;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace FluentNHibernateSQLiteCSharp.Session
{
    public static class SessionManager
    {
        private const string DatabaseName = "CashFlowManager.db";
        private static ISession _session;

        private static ISessionFactory CreateSessionFactory(IUnityContainer container)
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(DatabaseName))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IBaseEntity>())
                .ExposeConfiguration(x => x.SetInterceptor(new DependencyInjectionEntityInterceptor(container)))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            if (!File.Exists(DatabaseName))
            {
                new SchemaExport(config).Create(false, true);
            }
        }

        public static ISession GetInstance(IUnityContainer container)
        {
            if (_session == null)
                _session = CreateSessionFactory(container).OpenSession();
            return _session;
        }
    }
}