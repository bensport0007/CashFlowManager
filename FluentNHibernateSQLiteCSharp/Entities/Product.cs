using FluentNHibernateSQLiteCSharp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentNHibernateSQLiteCSharp.Entities
{
    public class Product : IProduct
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual IList<Store> StoresStockedIn { get; set; }
              
        public Product()
        {
            StoresStockedIn = new List<Store>();
        }
    }
}
