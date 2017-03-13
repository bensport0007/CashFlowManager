using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.IOC;
using FluentNHibernateSQLiteCSharp.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowManager.Domain.Services
{
    public class DonatorService
    {
        private IQueryHelper<Donator> _donatorQuerier;

        public DonatorService()
        {
            _donatorQuerier = DependencyFactory.Resolve<IQueryHelper<Donator>>();
        }

        public IList<Donator> GetAllDonators()
        {
            return _donatorQuerier.GetAll();
        }
    }
}
