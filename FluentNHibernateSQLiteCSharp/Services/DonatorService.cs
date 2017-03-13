using System;
using System.Collections.Generic;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Session;
using NHibernate;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public class DonatorService : IDonatorService
    {
        private readonly IQueryHelper<Donator> _donatorQuerier;
        private readonly ISession _session;

        public DonatorService(IQueryHelper<Donator> donatorQuerier, ISession session)
        {
            _donatorQuerier = donatorQuerier;
            _session = session;
        }

        public IList<Donator> GetAllDonators()
        {
            return _donatorQuerier.GetAll();
        }

        public void PersistDonators(IList<Donator> objectsToPersist)
        {
            var serv = new PersistenceService(_session);

            var transaction = _session.BeginTransaction();
            foreach(var items in objectsToPersist)
            { 
                //_session.SaveOrUpdate(items);
                serv.PersistData(items);
            }
            transaction.Commit();

            
            
            
        }
    }
}
