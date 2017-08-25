using System.Linq;
using System.Reflection;
using FluentNHibernateSQLiteCSharp.Entities;
using Microsoft.Practices.Unity;
using NHibernate;

namespace FluentNHibernateSQLiteCSharp.IOC
{
    public class DependencyInjectionEntityInterceptor : EmptyInterceptor
    {
        private readonly IUnityContainer _container;
        private ISession _session;

        public DependencyInjectionEntityInterceptor(IUnityContainer container)
        {
            _container = container;
        }

        public override void SetSession(ISession session)
        {
            _session = session;
        }

        public override object Instantiate(string clazz, EntityMode entityMode, object id)
        {
            if (entityMode == EntityMode.Poco)
            {
                var type = Assembly.GetAssembly(typeof(Donator)).GetTypes().FirstOrDefault(x => x.FullName == clazz);
                var hasParameters = type != null && type.GetConstructors().Any(x => x.GetParameters().Any());

                if (type != null && hasParameters)
                {
                    var instance = _container.Resolve<Donator>();

                    var md = _session.SessionFactory.GetClassMetadata(clazz);
                    md.SetIdentifier(instance, id, entityMode);
                    return instance;
                }
            }
            return base.Instantiate(clazz, entityMode, id);
        }
    }
}