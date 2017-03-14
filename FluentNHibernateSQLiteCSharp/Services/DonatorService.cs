using System.Collections.Generic;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Session;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public class DonatorService : IDonatorService
    {
        private readonly IQueryHelper<Donator> _donatorQuerier;

        public DonatorService(IQueryHelper<Donator> donatorQuerier)
        {
            _donatorQuerier = donatorQuerier;
        }

        public IList<Donator> GetAllDonators()
        {
            return _donatorQuerier.GetAll();
        }
    }
}