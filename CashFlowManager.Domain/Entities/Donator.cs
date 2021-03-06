﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernateSQLiteCSharp.Entities.Interfaces;

namespace FluentNHibernateSQLiteCSharp.Entities
{
    public class Donator : BaseEntity, IDonator
    {
        public virtual int Id { get; protected set; }
        public virtual int Number { get; set; } //We're reusing donator numbers so it can't be the id
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Year { get; set; }
    }
}
