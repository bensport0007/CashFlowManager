using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernateSQLiteCSharp.Entities.Interfaces;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace FluentNHibernateSQLiteCSharp.Session
{
    public static class SessionManager
    {
        private const string DatabaseName = "CashFlowManager.db";
        private static ISession _session;

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(DatabaseName))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IBaseEntity>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            if (!File.Exists(DatabaseName))
            {
                File.Delete(DatabaseName);
                new SchemaExport(config).Create(false, true);
            }
        }

        public static ISession GetInstance()
        {
            if (_session == null)
                _session = CreateSessionFactory().OpenSession();
            return _session;
        }
    }
}