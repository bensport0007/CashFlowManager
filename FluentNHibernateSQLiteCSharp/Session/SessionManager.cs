using NHibernate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernateSQLiteCSharp.Entities.Interfaces;

namespace FluentNHibernateSQLiteCSharp
{
    public static class SessionManager
    {
        private const string DATABASE_NAME = "CashFlowManager.db";
        private static ISession _session = null;

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(SQLiteConfiguration.Standard.UsingFile(DATABASE_NAME))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IBaseEntity>())
              .ExposeConfiguration(BuildSchema)
              .BuildSessionFactory();
        }
        
        private static void BuildSchema(Configuration config)
        {
            if (!File.Exists(DATABASE_NAME))
            {
                File.Delete(DATABASE_NAME);
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
