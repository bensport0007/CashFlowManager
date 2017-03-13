using FluentNHibernateSQLiteCSharp.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace FluentNHibernateSQLiteCSharp.Entities.Interfaces
{
    public interface IStore : IBaseEntity
    {
        int Id { get; set; }
        string Name { get; set; }
        IList<Product> Products { get; set; }
        IList<Employee> Staff { get; set; }

        void AddEmployee(Employee employee);
        void AddProduct(Product product);
    }
}
