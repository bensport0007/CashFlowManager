using FluentNHibernateSQLiteCSharp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentNHibernateSQLiteCSharp.Entities
{
    public class Transaction : BaseEntity, ITransaction
    {
        public virtual int Id { get; protected set; }
        public virtual Donator donator { get; set; }
        public virtual TransactionType type { get; set; }
        public virtual Post post { get; set; }
        public virtual DateTime date { get; set; }
        public virtual double amount { get; set; }
        public virtual DepositMethod depositMethod { get; set; }
    }
}
