//using Microsoft.Practices.Unity;
//using Microsoft.Practices.Unity.Configuration;
//using NHibernate;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FluentNHibernateSQLiteCSharp.IOC
//{
//    public class DependencyFactory
//    {
//        private static IUnityContainer _container;

//        public static IUnityContainer Container
//        {
//            get
//            {
//                if (_container == null)
//                    CreateFactory();
//                return _container;
//            }
//            private set
//            {
//                _container = value;
//            }
//        }

//        private static void CreateFactory()
//        {
//            var container = new UnityContainer();

//            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
//            if (section != null)
//            {
//                section.Configure(container);
//            }
//            _container = container;
//        }

//        public static T Resolve<T>()
//        {
//            T ret = default(T);

//            if (Container.IsRegistered(typeof(T)))
//            {
//                ret = Container.Resolve<T>();
//            }

//            return ret;
//        }

//        public static void Configure()
//        {
//            //_container.RegisterInstance<ISession>(SessionManager.GetInstance());
//        }
//    }
//}
