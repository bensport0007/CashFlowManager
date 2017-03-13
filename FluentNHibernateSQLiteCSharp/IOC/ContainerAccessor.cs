﻿using FluentNHibernateSQLiteCSharp;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowManagerDomain.IOC
{
    public static class ContainerAccessor
    {
        private static IUnityContainer _container;

        public static void ConfigureContainer(IUnityContainer container)
        {
            _container = container;

        }

        public static IUnityContainer Container()
        {
            if (_container == null) throw new Exception("Domain container is not initialized.");
            return _container;
        }

        public static T Resolve<T>()
        {
            T ret = default(T);

            if (_container.IsRegistered(typeof(T)))
            {
                ret = _container.Resolve<T>();
            }

            return ret;
        }
        
    }
}