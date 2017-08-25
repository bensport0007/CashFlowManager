using CashFlowManagerDomain.IOC;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Entities.Interfaces;
using FluentNHibernateSQLiteCSharp.IOC;
using FluentNHibernateSQLiteCSharp.Session;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces = FluentNHibernateSQLiteCSharp.Entities.Interfaces;

namespace FluentNHibernateSQLiteCSharp
{
    public class App
    {
        private IQueryHelper<Transaction> _transactionQueryHelper;
        private IQueryHelper<Donator> _donatorQueryHelper;
        private ISession _session;

        public App()
            : this(
                ContainerAccessor.Resolve<ISession>(),
                ContainerAccessor.Resolve<IQueryHelper<Transaction>>(),
                ContainerAccessor.Resolve<IQueryHelper<Donator>>()) { }

        public App(ISession session,
            IQueryHelper<Transaction> transactionQueryHelper,
            IQueryHelper<Donator> donatorQueryHelper)
        {
            _session = session;
            _transactionQueryHelper = transactionQueryHelper;
            _donatorQueryHelper = donatorQueryHelper;
        }

        public void Start()
        {
            using (_session)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    var transactionList = _transactionQueryHelper.GetAll();

                    //var transactionsList = _session.CreateCriteria<Transaction>().List<Transaction>().ToList();

                    var donator = _donatorQueryHelper.GetAllThatFitExpression(x => x.Number == 1).FirstOrDefault();

                    //var donator = _session.CreateCriteria<Donator>().List<Donator>().Where(x => x.Number == 1).FirstOrDefault();
                    var post = _session.CreateCriteria<Post>().List<Post>().FirstOrDefault();

                    //if (donator == null)
                    //{
                    //    var donator1 = new Donator {Number = 1, FirstName = "toto", LastName="pipo"};
                    //    _session.SaveOrUpdate(donator1);
                    //    donator = _session.CreateCriteria<Donator>().List<Donator>().FirstOrDefault(x => x.Id == 1);
                    //}

                    if (post == null)
                    {
                        var post1 = new Post { Number = 12, Description = "Description du poste"};
                        _session.SaveOrUpdate(post1);
                        post = _session.CreateCriteria<Post>().List<Post>().FirstOrDefault(x => x.Number == 12);
                    }
                    
                    var inTransaction = new Transaction()
                    {
                        amount = 123.12,
                        date = DateTime.Now,
                        depositMethod = DepositMethod.Cash,
                        donator = donator,
                        type = TransactionType.Inflow,
                        post = post
                    };

                    _session.SaveOrUpdate(inTransaction);
                    transaction.Commit();
                }
                Console.Read();
            }
        }
    }
}
