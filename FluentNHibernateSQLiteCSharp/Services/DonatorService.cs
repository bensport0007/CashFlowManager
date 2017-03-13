using System.Collections.Generic;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Session;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public class DonatorService : IDonatorService
    {
        private readonly IDataPersistenceService _dataPersistenceService;
        private readonly IQueryHelper<Donator> _donatorQuerier;

        public DonatorService(IQueryHelper<Donator> donatorQuerier, IDataPersistenceService dataPersistenceService)
        {
            _donatorQuerier = donatorQuerier;
            _dataPersistenceService = dataPersistenceService;
        }

        public IList<Donator> GetAllDonators()
        {
            return _donatorQuerier.GetAll();
        }

        public void PersistDonators(IList<Donator> objectsToPersist)
        {
            var donatorsAsObjects = DonatorsAsObjects(objectsToPersist);
            _dataPersistenceService.PersistData(donatorsAsObjects);
        }

        private static IEnumerable<object> DonatorsAsObjects(IEnumerable<Donator> objectsToPersist)
        {
            var donatorsAsObjects = new List<object>();
            foreach (var obj in objectsToPersist)
                donatorsAsObjects.Add(obj);
            return donatorsAsObjects;
        }
    }
}