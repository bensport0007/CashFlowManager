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
        private IQueryHelper<Employee> _employeeQueryHelper;
        private IQueryHelper<Transaction> _transactionQueryHelper;
        private IQueryHelper<Donator> _donatorQueryHelper;
        private ISession _session;

        public App()
            : this(
                ContainerAccessor.Resolve<ISession>(),
                ContainerAccessor.Resolve<IQueryHelper<Employee>>(),
                ContainerAccessor.Resolve<IQueryHelper<Transaction>>(),
                ContainerAccessor.Resolve<IQueryHelper<Donator>>()) { }

        public App(ISession session,
            IQueryHelper<Employee> employeeQueryHelper,
            IQueryHelper<Transaction> transactionQueryHelper,
            IQueryHelper<Donator> donatorQueryHelper)
        {
            _session = session;
            _employeeQueryHelper = employeeQueryHelper;
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

                    if (donator == null)
                    {
                        var donator1 = new Donator {Number = 1, FirstName = "toto", LastName="pipo"};
                        _session.SaveOrUpdate(donator1);
                        donator = _session.CreateCriteria<Donator>().List<Donator>().Where(x => x.Id == 1).FirstOrDefault();
                    }

                    if (post == null)
                    {
                        var post1 = new Post { Number = 12, Description = "Description du poste"};
                        _session.SaveOrUpdate(post1);
                        post = _session.CreateCriteria<Post>().List<Post>().Where(x => x.Number == 12).FirstOrDefault();
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

                    // create a couple of Stores each with some Products and Employees
                    var barginBasin = new Store { Name = "Bargin Basin" };
                    var superMart = new Store { Name = "SuperMart" };

                    var potatoes = new Product { Name = "Potatoes", Price = 3.60 };
                    var fish = new Product { Name = "Fish", Price = 4.49 };
                    var milk = new Product { Name = "Milk", Price = 0.79 };
                    var bread = new Product { Name = "Bread", Price = 1.29 };
                    var cheese = new Product { Name = "Cheese", Price = 2.10 };
                    var waffles = new Product { Name = "Waffles", Price = 2.41 };

                    var daisy = new Employee { FirstName = "Daisy", LastName = "Harrison" };
                    var jack = new Employee { FirstName = "Jack", LastName = "Torrance" };
                    var sue = new Employee { FirstName = "Sue", LastName = "Walkters" };
                    var bill = new Employee { FirstName = "Bill", LastName = "Taft" };
                    var joan = new Employee { FirstName = "Joan", LastName = "Pope" };
                    var bill2 = new Employee { FirstName = "Bill", LastName = "Pope" };

                    // add products to the stores, there's some crossover in the products in each
                    // store, because the store-product relationship is many-to-many
                    AddProductsToStore(barginBasin, potatoes, fish, milk, bread, cheese);
                    AddProductsToStore(superMart, bread, cheese, waffles);

                    // add employees to the stores, this relationship is a one-to-many, so one
                    // employee can only work at one store at a time
                    AddEmployeesToStore(barginBasin, daisy, jack, sue);
                    AddEmployeesToStore(superMart, bill, joan, bill2);

                    // save both stores, this saves everything else via cascading
                    _session.SaveOrUpdate(barginBasin);
                    _session.SaveOrUpdate(superMart);

                    
                }

                // retreive all stores and display them
                using (_session.BeginTransaction())
                {
                    var stores = _session.CreateCriteria(typeof(Store))
                      .List<Store>().Where(x => x.Name == "Bill");

                    foreach (var store in stores)
                    {
                        WriteStorePretty(store);
                    }

                    var employees = _session.CreateCriteria<Employee>().List<Employee>().Where(x => x.FirstName == "Bill").ToList();
                    var employees2 = _employeeQueryHelper.GetAllThatFitExpression(x => x.FirstName == "Bill");
                }

                Console.Read();
            }
        }

        public static void AddProductsToStore(Store store, params Product[] products)
        {
            //foreach (var product in products)
            //{
            //    store.AddProduct(product);
            //}
        }

        public static void AddEmployeesToStore(Store store, params Employee[] employees)
        {
            foreach (var employee in employees)
            {
                store.AddEmployee(employee);
            }
        }

        private static void WriteStorePretty(Store store)
        {
            Console.WriteLine(store.Name);
            Console.WriteLine("  Products:");

            //foreach (var product in store.Products)
            //{
            //    Console.WriteLine("    " + product.Name);
            //}

            Console.WriteLine("  Staff:");

            foreach (var employee in store.Staff)
            {
                Console.WriteLine("    " + employee.FirstName + " " + employee.LastName);
            }

            Console.WriteLine();
        }
    }
}
